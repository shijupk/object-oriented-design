# Vending Machine

Designing a Vending Machine that adheres to SOLID principles involves creating a system that is modular, flexible, and easy to maintain. The design should accommodate various types of products, payment methods, and user interactions while ensuring that the system is open for extension but closed for modification.

## Key Features of a Vending Machine

**Product Management:** Handles different types of products, their prices, and quantities.
**Payment Processing:** Supports different payment methods (e.g., cash, card, digital wallets).
**Inventory Management:** Manages the stock of products.
**User Interaction:** Allows users to select products, insert payments, and receive products.
**Transaction Management:** Manages the purchase process, including validating payment and dispensing the product.
**Maintenance and Restocking:** Provides functionality for maintenance, such as restocking products and collecting payments.

## Architecture Overview

**Product Management:** Manages the products and their details (price, quantity).
**Payment Processing:** Handles payment operations through different methods.
**Inventory Management:** Keeps track of available products.
**User Interaction:** Interfaces with the user for selection and payment.
**Transaction Management:** Orchestrates the entire transaction process.
