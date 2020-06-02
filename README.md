# Submission 1 for Application Modelling module (2018/19)
Module code | When | Module total
-- | - | -
COSE40574 | Semester 1, Year 1 | 81.625%

## Future Development
1. Create **seperate applications** for the admin and user instead of a single application
1. Implement **Software Engineering Principles** because the code stinks!

## Scenario
A company wants a computer system for managing events. Events can be added, updated and deleted. Users can book tickets for an event and cancel the bookings.
Each operation is recorded in a transaction log.
The computer system is to provide the following operations:
Operation | Information
-- | -
Add event | Read event code, name, number of tickets available, price per ticket, and date added. Store the data in an appropriate datastructure and make an entry into the transaction log.
Update event | Read event code, new name, new number of tickets available, new price per ticket, and date of update. If the event exists, modify the details and make an entry into the transaction log.
Delete event | Read event code. If the event exists, delete the event from the data structure and make an entry in the transaction log.
Book tickets | Read the event code, customer name and address, number of tickets to buy. If the event exists and there are enough tickets available, update the number of available tickets for the event; Add the booking details to a bookings data structure; Output the booking code, and total price of the booked tickets and make an entry in the transaction log.
Cancel booking | Read the booking code. If the booking exists, update the number of available tickets for the event; Delete the booking and make an entry in the transaction log.
Display list of events | Output the details of all events, including all bookings for each event.
Display transaction log | Output the list of all transaction log entries. Each record should show: Date of transaction; Type of transaction; Add (show event details); Update (show updated event details); Delete (show event code); Book (show event code, booking code, num. tickets); Cancel (show booking code, num. tickets)

## Assignment 1 (Procedural)
**Assignment total:** 99.375%
### Part 1
Develop a procedural model for a computer system to support the operations described above. All data in the system is either to be held within the program’s memory or stored in files (i.e. you are not to use a relational database management system).

Your model should include the following:
- Data Flow Diagrams
- Data Dictionary
- Pseudo-code
- Entity-Relationship Diagram, with column descriptions

In addition, write a report about linked lists, trees, heaps, queues and stacks. Your report should provide only the following details:
- For each data structure, briefly discuss whether the data structure could appropriately be used in a C# implementation of your model, and if so for what purpose.
- Choose which data structures you will use in Part 2, giving reasons for your decisions.

### Part 2
Implement your model using the C# programming language and write a test plan recording the actual results.
### Mark Scheme
#### Part 1
Criterion | Mark
-- | -
Data Flow Diagrams (25%) | 25
Pseudo-code (15%) | 14.25
Entity-Relationship Diagrams (15%) | 15
Data Dictionary (15%) | 15
Model Consistency (20%) | 20
Report (10%) | 10
**Total** | **99.25%**

#### Part 2
Criterion | Mark
-- | -
Test plan (20%) | 20
Add event (10%) | 10
Update event (10%) | 10
Delete event (10%) | 10
Book tickets (15%) | 15
Cancel booking (10%) | 10
Display all events (10%) | 9.5
Display transaction log (15%) | 15
**Total** | **99.5%**

## Assignment 2 (Object-oriented)
[View repo](http://github.com/DanBuxton/EventsManagementSystem-OOP)
