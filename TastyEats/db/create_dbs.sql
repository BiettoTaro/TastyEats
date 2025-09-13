CREATE DATABASE tastyeats WITH OWNER = postgres;
CREATE DATABASE tastyeats_test WITH OWNER = postgres;;

\connect tastyeats
\i /docker-entrypoint-initdb.d/schema.sql

\connect tastyeats_test
\i /docker-entrypoint-initdb.d/schema.sql
