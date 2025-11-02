# Setup
Follow for the setup:https://playwright.dev/docs/intro#installing-playwright


# 🧪 Energy Page – Test Plan

This document contains the complete functional test plan for the ** Energy** page, covering all major scenarios for Gas, Electricity, Oil, and Nuclear purchases.  
It is designed to guide manual QA, automation development, and regression validation.

---

## 📋 Overview

- **Application Area:** Energy Marketplace – BUY Page, SELL Page, Register, Login  
- **Primary Functions:** Purchase energy units, validate inputs, reflect stock changes, enforce boundaries, login, register and handle unavailable products.  
- **Initial Data:**  
  - Gas: **3000 units available**  
  - Nuclear: **0 units available**  
  - Electricity: **4322 units available**  
  - Oil: **20 units available**

---

## ✅ Test Cases

## 👤 User Registration Scenarios (UR)

| ID | Test Case | Steps | Expected Result |
|---|-----------|-------|------------------|
| UR1 | Successful registration (happy path) | Open Register → Fill valid First/Last Name, unique Email, strong Password, Confirm Password → Submit | Account created; redirected or success message displayed |
| UR2 | Required fields | Leave one required field blank → Submit | Inline validation for missing field; no account created |
| UR3 | Email format validation | Enter invalid email (e.g., `user@bad`) → Submit | Email format error shown |
| UR4 | Password strength | Enter weak password (below policy) → Submit | Strength error shown; guidance displayed |
| UR5 | Password confirmation mismatch | Enter different Confirm Password → Submit | Mismatch error; no account created |
| UR6 | Duplicate email | Register with an email that already exists → Submit | “Email already in use” error; no account created |
| UR7 | Rate limiting | Submit registration repeatedly in quick succession | Rate limit or captcha (if implemented) prevents abuse |
| UR8 | Accessibility of form | Tab through fields, submit with Enter | Logical focus order; ARIA labels; can register via keyboard |
| UR9 | Success redirect | After success, follow redirect | Lands on expected page (e.g., dashboard or BUY page) |
| UR10| Allow only logged in authorized users to do BUY/SELL energy| After successful login users then able to BUY/SELL | If not logged in then BUY/SELL should be hidden|

### 🔥BUY GAS Scenarios

### Before each test ensure to browse to specific page and also hit the 'Reset' button for the amount to reset.

| # | Test Case | Steps | Expected Result |
|---|-----------|-------|------------------|
| 1 | BUY valid amount of GAS | Enter a valid number (1–3000) → Click Buy | Purchase succeeds; stock reduced correctly |
| 2 | Gas Stock gets reflected correctly | Note stock → Buy 1000 → Check stock | New stock = 3000 - 1000 |
| 3 | BUY Gas above available units | Enter 3001 → Click Buy | Error shown; stock unchanged |
| 4 | BUY Gas with negative unit | Enter -5 → Click Buy | Error shown; stock unchanged |
| 5 | GAS stock reduction only | Buy 10 Gas → Verify other stocks | Only Gas reduces |
| 6 | BUY exactly available Gas | Enter 3000 → Buy | Success; stock becomes 0; Gas unavailable |
| 7 | Zero units invalid | Leave input as 0 → Buy | Error shown or button disabled |
| 8 | Decimal quantity invalid | Enter 1.5 → Buy | Validation error |
| 9 | Non-numeric input rejected | Enter "abc" → Buy | Error shown |
| 10 | Leading/trailing spaces handled | Enter "  10  " → Buy | Parsed as 10; stock reduced |

---

### ⚡ ELECTRICITY Scenarios

| # | Test Case | Steps | Expected Result |
|---|-----------|-------|------------------|
| 11 | BUY valid Electricity amount | Enter 50 → Buy | Success; stock reduced by 50 |
| 12 | Electricity stock reflected | Note stock → Buy 100 → Check stock | Stock = initial - 100 |
| 13 | BUY above available Electricity | Enter 4323 → Buy | Error; stock unchanged |
| 14 | Negative Electricity rejected | Enter -10 → Buy | Error; stock unchanged |
| 15 | Zero or decimal Electricity rejected | Enter 0 or 2.5 → Buy | Error shown; no change |

---

### 🛢️ OIL Scenarios

## 📜 SOME Observed DEFECTS OBSERVED
1- CAN BUY GAS AND OTHER RESOURCES WITHOUT LOGGING IN AS A GUEST
2- Having to have to reset each time after purchasing Gas
