# 🔐 Secure Authentication System (JWT + Refresh Tokens)

![.NET Core](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![React](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=json%20web%20tokens)

> **A robust, session-like authentication mechanism implementing the "Silent Refresh" pattern to ensure seamless user experiences without compromising security.**

---

## 📋 Table of Contents
- [System Purpose](#-system-purpose)
- [Technology Stack](#-technology-stack)
- [Architecture](#-architecture)
- [Authentication Flow](#-authentication-flow)
- [Token Strategy](#-token-strategy)
- [Database Schema](#-database-schema)
- [Security Features](#-security-features)
- [Future Roadmap](#-future-roadmap)

---

## 🎯 System Purpose
This system provides a secure authentication backbone designed to minimize user friction while maintaining high security standards.

**Key Goals:**
* **Single Sign-On Feel:** Users log in once and remain authenticated as long as they are active.
* **Zero Interruption:** Expired tokens are auto-renewed in the background without user intervention.
* **Statelessness:** Leverages JWTs to avoid server-side session bloat.
* **Production Readiness:** Designed to be testable, observable, and scalable.

---

## 🛠 Technology Stack

### **Backend**
* **Framework:** ASP.NET Core (.NET 8)
* **ORM:** Entity Framework Core
* **Database:** SQLite (Local/Testing), adaptable to Postgres/SQL Server
* **Auth:** JWT (JSON Web Tokens) + Refresh Tokens

### **Frontend**
* **Framework:** React
* **HTTP Client:** Axios (w/ Interceptors)
* **Storage:** LocalStorage (for token persistence)

---

## 🏗 Architecture

The system follows a decoupled architecture where the React frontend communicates with the .NET API via RESTful endpoints.

```mermaid
graph TD
    User[👤 User] -->|Credentials| UI[⚛️ React UI]
    UI -->|Login Request| API[🛡️ Auth API .NET]
    API -->|Validate User| DB[(🗄️ SQLite DB)]
    DB -->|Return User Data| API
    API -->|Issue JWT + Refresh Token| UI
    UI -->|Store Tokens| LocalStorage[💾 LocalStorage]