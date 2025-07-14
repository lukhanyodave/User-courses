# User-courses
student and Teacher Courses management 

Student Workflow:
 Students log on or sign up via the SPA (using Azure AD authentication).
 Students complete their profile, capturing:
 Address information
 Contact phone number
 Students can request to register for available courses.
 Some courses have pre-requisites of other courses before they can be
registered.
 Each course consists of 1 to 5 modules.
 Students can mark modules as completed.
 Students can view their progress and grades.
Teacher Workflow:
 Teachers sign in via the SPA (using Azure AD authentication).
 Teachers can view course registration requests.
 Teachers approve or reject student registrations for courses.
 Teachers can grade/mark completed modules for each student.



 Teachers can view and manage student progress.
Course and Grading Rules:
 A course consists of 1 to 5 modules.
 Each module can be marked as completed by the student.
 Each module is graded by the teacher.
 The overall course score is the average of all module grades.
 A student passes a course if their overall average is at least 68%.
 A course has a name and description
 A module also have a name and description and sequence number in which it
must be completed.



Technical Requirements:
 All profile, course, registration, and grading data must be stored and retrieved
via the API.
 Entity Framework Core (EFCore) must be used for database access in the
API.
 The application must include validation where necessary (e.g., user input,
business rules).
 Create Unit tests where necessary
 The application should follow SOLID principles and best practices in
architecture and code organization.
 Authentication and authorization are handled via Azure AD.
 The solution must demonstrate both student and teacher roles and workflows.
 The teacher user can be pre-added, and with a teacher role, with database
initialization
 All other logins can be assumed to be students
 With database initialization/seeding
o Seed Teacher Users
o Seed Courses and Modules, and any other tables/entities as needed
 The application will be scored on implementation quality, adherence to
requirements, and code best practices.
