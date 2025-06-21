# 🛒 Shop – User Story Documentation (EPIC & Detailed Stories)

This document defines the high-level business goals and detailed user stories for the **Shop** proof of concept, developed using **.NET 8,  WebAssembly, and Blazor Hybrid (MAUI)** with **DDD, CQRS, and TDD** principles.

![Test Status](https://github.com/USERNAME/REPOSITORY_NAME/actions/workflows/RunTest.yml/badge.svg)

---

## 📌 EPIC: Full Shopping Experience

> As a customer, I want to browse available products, add items to my cart, apply discounts, place orders, and make secure payments so that I can complete my purchase conveniently.

---

## 📘 User Stories

### ✅ \[US001] Browse Products

**As a** customer,
**I want to** view a list of available products with names, prices, and stock status,
**So that** I can choose which items to add to my cart.

* **Query:** `GetAvailableProductsQuery`
* **Acceptance Criteria:**

  * Products are shown in cards or list format
  * Each product displays name, price, and availability

---

### ✅ \[US002] Add Product to Cart

**As a** customer,
**I want to** add a selected product with a quantity to my cart,
**So that** I can later check out and place an order.

* **Command:** `AddProductToCartCommand`
* **Acceptance Criteria:**

  * Cart updates to include selected product
  * Quantity is validated against stock
  * Total price updates accordingly

---

### ✅ \[US003] Apply Discount Code

**As a** customer,
**I want to** enter a valid discount code,
**So that** I can receive a reduced price before checkout.

* **Command:** `ApplyDiscountCommand`
* **Acceptance Criteria:**

  * Valid codes reduce total price (e.g., 10% off)
  * Invalid/expired codes show error message
  * Discount applied persists until checkout

---

### ✅ \[US004] View Cart Summary

**As a** customer,
**I want to** review my cart contents and see a summary including discounts,
**So that** I can make changes before checking out.

* **Query:** `GetCartSummaryQuery`
* **Acceptance Criteria:**

  * Summary includes each item, quantity, total price
  * Discount, subtotal, and final total are shown

---

### ✅ \[US005] Place an Order

**As a** customer,
**I want to** confirm and place my cart as a final order,
**So that** the system records it for fulfillment.

* **Command:** `PlaceOrderCommand`
* **Acceptance Criteria:**

  * Order created from cart contents
  * Unique Order ID is returned
  * Cart is cleared post-order

---

### ✅ \[US006] Pay for an Order

**As a** customer,
**I want to** pay for my confirmed order,
**So that** the transaction completes and my order is processed.

* **Command:** `PayOrderCommand`
* **Acceptance Criteria:**

  * Payment reflects total (after discount)
  * Payment status updates (pending ➝ completed)
  * Confirmation is shown to user

---

## 🧰 Notes:

* All User Stories support **CQRS**: Commands modify state, Queries retrieve projections
* All logic is implemented in an **In-Memory Domain Layer** (no DB)
* Test cases will follow each story with **TDD-first** strategy
* Interfaces and Services are decoupled via **Dependency Injection**
