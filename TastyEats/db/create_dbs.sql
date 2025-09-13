CREATE DATABASE tastyeats;
CREATE DATABASE tastyeats_test;

\connect tastyeats
\i /docker-entrypoint-initdb.d/schema.sql

\connect tastyeats_test
\i /docker-entrypoint-initdb.d/schema.sql
