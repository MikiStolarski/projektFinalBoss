# Service Ticket System
 
## Opis projektu
 
System do rejestracji i weryfikacji zgłoszeń serwisowych.
 
Projekt składa się z:
 
* Backend: ASP.NET Core Web API
* Frontend: React + Tailwind CSS
* Testy jednostkowe: MSTest
* Serializacja danych do pliku JSON
 
---
 
# Technologie
 
## Backend
 
* C#
* ASP.NET Core Web API
* System.Text.Json
* DataAnnotations
* Dependency Injection
 
## Frontend
 
* React
* Vite
* Tailwind CSS
 
## Testy
 
* MSTest
* WebApplicationFactory
* TestAdapter
* TestFramework
 
---
 
### Pola
 
| Pole        | Typ                     | Opis                 |
| ----------- | ------------------------| -------------------- |
| Id          | Guid                    | Id zgłoszenia        |
| FullName    | string                  | Imię i nazwisko      |
| Email       | string                  | Adres e-mail         |
| Description | string                  | Opis problemu        |
| Category    | ServiceTicketCategories | Kategoria zgłoszenia |
| CreatedAt   | DateTime                | Data utworzenia      |
 
---
 
# Endpointy API
 
## GET /api/tickets
 
Pobiera listę zgłoszeń.
 
### Output
 
```json
[
  {
    FullName = "hans",
    Email = "leonid",
    Description = "Problemik z drukarkom",
    Category = ServiceTicketCategories.Hardware
  }
]
```
 
---
 
## POST /api/tickets
 
Dodaje nowe zgłoszenie.
 
### Input
 
```json
{
  FullName = "hans",
  Email = "leonid",
  Description = "Problemik z drukarkom",
  Category = ServiceTicketCategories.Hardware
}
```
 
### Output
 
```json
{
  "message": "Tikecik dodany"
}
```
 
---
 
# Walidacja
 
Walidacja realizowana jest przez:
 
* DataAnnotations
* ServiceTicketValidator
 
## Sprawdzane dane
 
* wymagane pola (Fullname, email, Description)
* poprawność e-mail
* minimalna długość opisu
 
---
 
# Delegaty
 
Projekt wykorzystuje delegat:
 
```c#
public delegate void TicketAddedHandler(ServiceTicket ticket);
```
 
## Akcje po dodaniu zgłoszenia
 
* logowanie do konsoli
* symulacja wysyłki e-mail
 
---
 
# Serializacja JSON
 
Dane zgłoszeń zapisywane są do pliku:
 
```
tickets.json
```
 
Wykorzystana biblioteka:
 
```csharp
System.Text.Json
```
 
---
 
# Testy jednostkowe
 
## Testowane elementy
 
* walidacja danych
* działanie delegatów
* serializacja i deserializacja
* endpointy API
 
---
 
# Frontend
 
## Funkcjonalności
 
* formularz zgłoszenia
* walidacja formularza
* lista zgłoszeń
* komunikaty sukces/błąd
 
---
 
# Uruchomienie projektu
 
## Backend
 
```bash
wchodzimy do localhosta
```
 
## Frontend
 
```bash
npm install
npm run dev
wchodzimy do localhosta
```
 
---
