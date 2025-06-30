CREATE DATABASE IF NOT EXISTS cosmetics_db;
USE cosmetics_db;

CREATE TABLE IF NOT EXISTS products (
    id INT PRIMARY KEY AUTO_INCREMENT,
    type VARCHAR(100) NOT NULL,
    brand VARCHAR(100) NOT NULL,
    manufacturer VARCHAR(100) NOT NULL,
    expiration_date DATE NOT NULL,
    price DECIMAL(10,2) NOT NULL
);
