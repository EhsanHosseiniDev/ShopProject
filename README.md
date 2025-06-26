# 🛒 Shop – User Story Documentation

This project is a **proof-of-concept shopping experience** built using **.NET 8**, **WebAssembly**, and **Blazor Hybrid (MAUI)**. The architecture follows **DDD**, **CQRS**, and **Clean Architecture** principles.

![Test Status](https://github.com/EhsanHosseiniDev/ShopProject/actions/workflows/RunTest.yml/badge.svg)
![Last Commit](https://img.shields.io/github/last-commit/EhsanHosseiniDev/ShopProject)
![.NET](https://img.shields.io/badge/.NET-8.0-blue)

---

## 📌 EPIC: Full Shopping Experience

> As a customer, I want to browse products, manage my cart, apply discounts, place an order, and complete payment — all within a smooth and reliable shopping flow.

---

## 📘 User Stories

### ✅ \[US001] Browse Products

**As a** customer,
**I want to** view a paginated list of available products with names, prices, and stock status,
**So that** I can choose which items to add to my cart.

* **Query:** `GetProductsQuery(int Page, int PageSize)`
* **Acceptance Criteria:**

  * Products are listed with name, price, availability
  * Supports pagination with `Page` and `PageSize`

---

### ✅ \[US002] Add Product to Cart

**As a** customer,
**I want to** add a selected product with a quantity to my cart,
**So that** I can later check out and place an order.

* **Command:** `AddProductToCartCommand(Guid CustomerId, Guid ProductId, int Quantity)`
* **Acceptance Criteria:**

  * Product is added if quantity is valid and in stock
  * Cart updates with new item and price

---

### ✅ \[US003] Remove Product from Cart

**As a** customer,
**I want to** remove a product from my cart,
**So that** I can update my order before checkout.

* **Command:** `RemoveProductFromCartCommand(Guid CustomerId, Guid ProductId)`
* **Acceptance Criteria:**

  * Product is removed from cart
  * Cart totals are updated

---

### ✅ \[US004] Update Cart Item Quantity

**As a** customer,
**I want to** change the quantity of a product in my cart,
**So that** I can increase or decrease my purchase amount.

* **Command:** `UpdateCartItemQuantityCommand(Guid CustomerId, Guid ProductId, int NewQuantity)`
* **Acceptance Criteria:**

  * Quantity updated if valid
  * Setting quantity to 0 removes item

---

### ✅ \[US005] View Cart Summary

**As a** customer,
**I want to** review the contents of my cart and see a summary including totals and discounts,
**So that** I can verify before placing an order.

* **Query:** `GetCartSummaryQuery(Guid CustomerId)`
* **Acceptance Criteria:**

  * Summary includes all cart items, quantities, subtotal, discounts, total

---

### ✅ \[US006] Place an Order

**As a** customer,
**I want to** place an order using my cart contents and a discount code,
**So that** the system can process my purchase.

* **Command:** `PlaceOrderCommand(Guid CustomerId, string discountCode)`
* **Acceptance Criteria:**

  * Valid cart is converted to order
  * Discount applied if valid
  * Unique order ID returned

---

### ✅ \[US007] Pay for Order

**As a** customer,
**I want to** pay for a confirmed order using a selected payment method,
**So that** the transaction is completed and the order can be fulfilled.

* **Command:** `PayOrderCommand(Guid OrderId, string PaymentMethod)`
* **Acceptance Criteria:**

  * Payment processes and updates status
  * Confirmation message shown

---

## 🧰 Technical Notes

* Uses **CQRS**: Commands mutate state, Queries return DTOs
* **All logic** handled in an **in-memory domain** (no database)
* Built on **Blazor Hybrid (MAUI)** for cross-platform support
* Designed with **Clean Architecture** and **Dependency Injection**
