# E-Commerce Application - LINQ and Entity Framework Core

## Overview

This project is a simple e-commerce application built using **Entity Framework Core** and **LINQ**. It demonstrates the basic structure of a database and relationships between entities, such as products, categories, orders, and customers. The application uses a console interface to test database operations and queries.

## Technologies Used

- **C#** (for building the console application)
- **Entity Framework Core** (for database interaction)
- **LINQ** (for querying data)
- **SQL Server** (local database for testing)

## Entities

The following entities have been created as part of the project:

- **Product**: Represents products in the e-commerce system.
- **Category**: Represents product categories.
- **Supplier**: Represents suppliers providing products.
- **Order**: Represents customer orders.
- **OrderDetail**: Represents the details of each item within an order.
- **Customer**: Represents customers of the e-commerce platform.

## Features

- Creation of database models using **Entity Framework Core** (Code First).
- **Relationships** between models (1-to-many, many-to-many) are properly configured.
- **LINQ queries** for various operations like fetching products, calculating total order values, etc.
  
## How to Run the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/JonssonF/Labb1---LINQ.git
