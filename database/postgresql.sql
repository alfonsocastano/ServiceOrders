CREATE TABLE users
(
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    is_deleted BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NULL
);

CREATE TABLE technicians
(
    id SERIAL PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    phone VARCHAR(30) NOT NULL,
    specialty VARCHAR(100) NOT NULL,
    is_deleted BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NULL
);

CREATE TABLE customers
(
    id SERIAL PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    document_number VARCHAR(50) UNIQUE NOT NULL,
    address VARCHAR(200) NOT NULL,
    phone VARCHAR(30) NOT NULL,
    is_deleted BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NULL
);

CREATE TABLE service_orders
(
    id SERIAL PRIMARY KEY,
    description TEXT NOT NULL,
    status INTEGER NOT NULL,
    technician_id INTEGER NOT NULL,
    customer_id INTEGER NOT NULL,
    is_deleted BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NULL,

    CONSTRAINT fk_service_order_technician
        FOREIGN KEY (technician_id)
        REFERENCES technicians(id),

    CONSTRAINT fk_service_order_customer
        FOREIGN KEY (customer_id)
        REFERENCES customers(id)
);