

Solution Structure Overview

The starter solution is organized into the following projects:

- **AppHost**: The entry point for hosting the application. This project is responsible for application startup, configuration, and dependency injection setup. It may be used to host the API and serve the SPA in production scenarios.

- **Skunkworks.Spa**: The Blazor WebAssembly Single Page Application (SPA) project. This is the client-side application where students and teachers interact with the system via a web browser. It communicates with the API for all data operations and handles authentication via Azure AD.
- **Note:** The SPA uses the FluentUI Blazor UI library for its user interface components by default, but you may switch to any other Blazor-compatible UI library if preferred.
- **Authentication:** Azure AD B2C is used for authentication and is already configured correctly in the starter solution.

- **SomeService.Api**: The ASP.NET Core Web API project. This project exposes RESTful endpoints for all business logic, data access, and validation. It uses Entity Framework Core (EFCore) for database access and enforces authentication, authorization, and business rules.
- **Note:** The API is configured for Azure AD B2C authentication. The included Weather page/controller demonstrates authenticated API access using this configuration.

- **Skunkworks.Shared**: A shared class library containing common models, DTOs, and validation logic used by both the SPA and API projects. This ensures consistency in data contracts and validation rules across the solution.

This structure supports clean separation of concerns, code reuse, and adherence to best practices for modern .NET solutions.

Assessment Requirements

- Build a Blazor Client SPA
- Build an ASP.NET API

Business Scenario

Student Workflow:
- Students log on or sign up via the SPA (using Azure AD authentication).
- Students complete their profile, capturing:
  - Address information
  - Contact phone number
- Students can request to register for available courses.
- Some courses have pre-requisites of other courses before they can be registered.
- Each course consists of 1 to 5 modules.
- Students can mark modules as completed.
- Students can view their progress and grades.

Teacher Workflow:
- Teachers sign in via the SPA (using Azure AD authentication).
- Teachers can view course registration requests.
- Teachers approve or reject student registrations for courses.
- Teachers can grade/mark completed modules for each student.
- Teachers can view and manage student progress.

Course and Grading Rules:
- A course consists of 1 to 5 modules.
- Each module can be marked as completed by the student.
- Each module is graded by the teacher.
- The overall course score is the average of all module grades.
- A student passes a course if their overall average is at least 68%.
- A course has a name and description
- A module also have a name and description and sequence number in which it must be completed.

Technical Requirements:

- All profile, course, registration, and grading data must be stored and retrieved via the API.
- Entity Framework Core (EFCore) must be used for database access in the API.
- The application must include validation where necessary (e.g., user input, business rules).
- Create Unit tests where necessary
- The application should follow SOLID principles and best practices in architecture and code organization.
- Authentication and authorization are handled via Azure AD.
    -   base solution either adds a Role Claim for "Teacher" or "Student" to the ClaimsPrincipal
- The solution must demonstrate both student and teacher roles and workflows.
- The teacher user can be pre-added, and with a teacher role, with database initialization
    - All other logins can be assumed to be students
- With database initialization/seeding
    - Seed Teacher Users
    - Seed Courses and Modules, and any other tables/entities as needed
- The application will be scored on implementation quality, adherence to requirements, and code best practices.

Scoring Sheet (for Interview Assessment):

| Area                        | Criteria                                                      | Max Points |
|-----------------------------|---------------------------------------------------------------|------------|
| Requirements Coverage       | All features implemented as per requirements                  |     20     |
| Code Quality & SOLID        | Follows SOLID, clean code, best practices, maintainability    |     20     |
| EFCore Usage                | Proper use of EFCore, migrations, relationships, queries      |     15     |
| Validation                  | Input and business rule validation implemented                |     10     |
| Authorization               | role-based access                                             |     10     |
| UI/UX                       | Usability, clarity, error handling, feedback                  |     10     |
| Testing                     | Unit/integration tests, testability                           |     10     |
| Documentation               | Clear README, code comments, requirements, instructions       |      5     |
| **Total**                   |                                                               |   **100**  |

Controller Implementation Instructions:

The API must include the following controllers, each with the required endpoints and logic:

1. **ProfileController**
   - CRUD endpoints for student profile (GET, POST, PUT, DELETE as appropriate)
   - Only allow students to access and update their own profile
   - Input validation for required fields (address, phone, etc.)

2. **CourseController**
   - Endpoints to list all courses, get course details, and list available courses for registration
   - Enforce course pre-requisite logic when registering
   - Endpoints for teachers to create, update, and manage courses and modules
   - Seed initial courses and modules on database initialization

3. **RegistrationController**
   - Endpoints for students to request course registration
   - Endpoints for teachers to approve/reject registrations
   - Ensure only teachers can approve/reject
   - Enforce that students cannot register for courses without meeting pre-requisites

4. **ModuleController**
   - Endpoints for students to mark modules as completed
   - Endpoints for teachers to grade/mark modules
   - Enforce module completion sequence

5. **UserController** (optional/bonus)
   - Endpoints to list users, assign roles, or view user details (for admin/teacher roles)

General Requirements for All Controllers:
- Use proper HTTP verbs and status codes
- Apply role-based authorization (student/teacher)
- Use dependency injection and follow SOLID principles
- Validate all input and return meaningful error messages

- Write unit tests for controller logic

**Developer Evaluation Focus:**

During the assessment, we will be evaluating the following key areas:

1. **Requirements Coverage**
   - Have all specified features and workflows (student and teacher) been implemented?
   - Are business rules (e.g., prerequisites, grading, module sequence) enforced?

2. **Code Quality & SOLID Principles**
   - Is the code clean, well-structured, and maintainable?
   - Are SOLID principles and best practices followed (e.g., separation of concerns, dependency injection)?

3. **EFCore Usage**
   - Is Entity Framework Core used appropriately for data access?
   - Are relationships, migrations, and queries implemented correctly?

4. **Validation**
   - Is input validation present for all relevant endpoints and models?
   - Are meaningful error messages returned for invalid input or business rule violations?

5. **Authentication & Authorization**
   - Is Azure AD authentication integrated?
   - Are role-based access controls enforced (student/teacher)?

6. **UI/UX**
   - Is the user interface clear, usable, and responsive?
   - Are errors and feedback handled gracefully?

7. **Testing**
   - Are there unit and/or integration tests for key logic and controllers?
   - Is the codebase testable and maintainable?

8. **Documentation**
   - Is there a clear README and in-code documentation?
   - Are setup, usage, and requirements instructions provided?

**Bonus:**
- Implementation of optional/bonus features (e.g., UserController, advanced admin features)
- Demonstration of advanced best practices or architectural patterns



