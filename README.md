# Client Service

Manages client data and eligibility within the Car Rental system.

## Role in System

The Client Service is responsible for maintaining client information and
their ability to interact with the system.

It provides client status to the Rental Service, which uses this
information to allow or prevent rentals.

For full system context, refer to the Rental Service repository.

---

## Table: Clients

| Column         | Type   | Description             |
|----------------|--------|-------------------------|
| id             | int    | Unique identifier       |
| name           | string | Client name             |
| cpf_number     | string | Brazilian document      |
| phone_number   | string | Phone number            |
| email          | string | Email address           |
| status         | int    | Active / Blocked        |

---

## Status

- `active` → Client is allowed to rent vehicles  
- `blocked` → Client is restricted from renting  

---

## API

- GET /clients  
- POST /clients  
- PATCH /clients/{id}/status  

---

## System Context

This service is part of the Car Rental Microservices System.

The Rental Service is the central service responsible for business rules
and orchestration.

See full system description:  
https://github.com/AmonAmarth2003/car-rental-rental-service