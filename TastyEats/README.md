# TastyEats – Setup Guide

This project uses Docker to provide a ready-to-use PostgreSQL database.
You do not need to install PostgreSQL manually.

Requirements

Docker Desktop
 (Windows/macOS)

Or Docker Engine (Linux)

## How to Start the Database

Open a terminal in the project folder (where docker-compose.yml is located).

Run:

docker-compose up -d


This will:

Start a PostgreSQL container

Create two databases:

tastyeats → main app database

tastyeats_test → used for automated tests

Load all the tables from schema.sql

## (Optional) Access Adminer at http://localhost:8080

System: PostgreSQL

Server: db (inside Docker) or localhost

Username: postgres

Password: postgres123

Database: tastyeats

## Application Configuration

The application connects to PostgreSQL with the following defaults (set in DatabaseHandler.cs):

Host: localhost

Port: 5432

User: postgres

Password: postgres123

Database: tastyeats

## Running Tests

The integration tests run automatically against tastyeats_test.
The Docker setup creates this database using the same schema as the main one.

## Stopping the Database

When finished, run:

docker-compose down