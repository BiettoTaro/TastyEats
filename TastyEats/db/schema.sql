-- Drop existing tables in correct order to avoid FK issues
DROP TABLE IF EXISTS cart_items, carts, order_items, payments, orders, menu_items, categories, customers, admins CASCADE;

-- =====================
-- Customers
-- =====================
CREATE TABLE customers (
    customer_id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    email VARCHAR(30) UNIQUE NOT NULL,
    password_hash VARCHAR(100) NOT NULL,
    phone VARCHAR(15),
    address VARCHAR(255),
    is_active BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT NOW()
);

-- =====================
-- Admins
-- =====================
CREATE TABLE admins (
    admin_id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    email VARCHAR(30) UNIQUE NOT NULL,
    password_hash VARCHAR(100) NOT NULL,
    employee_id INT UNIQUE NOT NULL,
    admin_role VARCHAR(50) NOT NULL,
    is_active BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT NOW()
);

-- =====================
-- Categories
-- =====================
CREATE TABLE categories (
    category_id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    description VARCHAR(500)
);

-- =====================
-- Menu Items
-- =====================
CREATE TABLE menu_items (
    item_id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    description VARCHAR(500),
    price DECIMAL(10,2) NOT NULL,
    category_id INT NOT NULL REFERENCES categories(category_id),
    is_available BOOLEAN NOT NULL DEFAULT TRUE,
    admin_id INT NOT NULL REFERENCES admins(admin_id),
    image_path VARCHAR(255) -- <- consistent with your C# mapper
);

-- =====================
-- Orders
-- =====================
CREATE TABLE orders (
    order_id SERIAL PRIMARY KEY,
    customer_id INT NOT NULL REFERENCES customers(customer_id),
    order_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(20) NOT NULL,
    total_amount DECIMAL(10,2) NOT NULL
);

-- =====================
-- Order Items
-- =====================
CREATE TABLE order_items (
    order_item_id SERIAL PRIMARY KEY,
    order_id INT NOT NULL REFERENCES orders(order_id) ON DELETE CASCADE,
    item_id INT NOT NULL REFERENCES menu_items(item_id),
    quantity INT NOT NULL,
    price_at_order DECIMAL(10,2) NOT NULL,
    notes TEXT
);

-- =====================
-- Payments
-- =====================
CREATE TABLE payments (
    payment_id SERIAL PRIMARY KEY,
    order_id INT NOT NULL REFERENCES orders(order_id),
    payment_method VARCHAR(50) NOT NULL,
    status VARCHAR(20) NOT NULL,
    transaction_timestamp TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    amount DECIMAL(10,2) NOT NULL
);

-- =====================
-- Carts
-- =====================
CREATE TABLE carts (
    cart_id SERIAL PRIMARY KEY,
    customer_id INT NOT NULL REFERENCES customers(customer_id)
);

-- =====================
-- Cart Items
-- =====================
CREATE TABLE cart_items (
    cart_item_id SERIAL PRIMARY KEY,
    cart_id INT NOT NULL REFERENCES carts(cart_id) ON DELETE CASCADE,
    item_id INT NOT NULL REFERENCES menu_items(item_id),
    quantity INT NOT NULL
);

-- =====================
-- Seed Data
-- =====================

-- Admin (password = "password", SHA256 hash matches your AuthController)
INSERT INTO admins (admin_id, name, email, password_hash, employee_id, admin_role, is_active)
VALUES
  (1, 'Admin', 'admin@example.com',
   '5E884898DA28047151D0E56F8DC6292773603D0D6AABBEDD5C8D6A7DF50A44C3',
   1, 'Manager', TRUE)
ON CONFLICT (admin_id) DO NOTHING;

-- Categories
INSERT INTO categories (category_id, name, description)
VALUES
  (1, 'Starters', 'Appetizers and small plates'),
  (2, 'Mains', 'Main dishes'),
  (3, 'Desserts', 'Sweet dishes'),
  (4, 'Drinks', 'Beverages')
ON CONFLICT (category_id) DO NOTHING;

-- Menu Items
INSERT INTO menu_items (item_id, name, description, price, image_path, category_id, admin_id, is_available)
VALUES
  (1, 'Tagliere Salumi & Formaggi', 'Charcuterie board with cured meats and cheese', 12.00, 'images/tagliere_salumi.jpg', 1, 1, TRUE),
  (2, 'Fregola allo Scoglio', 'Sardinian pasta with seafood', 25.00, 'images/fregola.jpg', 2, 1, TRUE),
  (3, 'Porcetto con Patate', 'Roasted suckling pig with potatoes', 27.00, 'images/porcetto.jpg', 2, 1, TRUE),
  (4, 'Seadas', 'Sardinian pastry filled with cheese served with sugar or honey', 10.00, 'images/seadas.jpg', 3, 1, TRUE),
  (5, 'Tiramisu', 'Classic Italian dessert made with ladyfingers, mascarpone and coffee', 9.00, 'images/tiramisu.jpg', 3, 1, TRUE),
  (6, 'Panna Cotta', 'Classic Italian dessert served with fresh berries', 8.00, 'images/panna_cotta.jpg', 3, 1, TRUE),
  (7, 'Cozze Gratinate', 'Gratinated mussels with herbs and breadcrumbs', 13.00, 'images/cozze_gratinate.jpg', 1, 1, TRUE),
  (8, 'Insalata di Polpi', 'Octopus salad with potatoes, celery, and parsley', 15.00, 'images/insalata_di_polpi.jpg', 1, 1, TRUE)
ON CONFLICT (item_id) DO NOTHING;
