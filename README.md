# Hristoslav-Zahariev-employees
An application that finds the employee pair that has worked the longest on one project.

# Steps to run the project
Prerequisites: .NET, Node, Visual Studio, Visual Studio Code.

Step 1. Open the solution(.sln file) in Visual Studio;\
Step 2. Run the API;\
Step 3. Open the EmployeePairFinder.Web folder in Visual Studio Code;\
Step 4. Open a new terminal and type the command "npm install";\
Step 5. Type the command "ng serve --open" in the terminal.

NOTE!: In order for the application to run properly, a base url for the front end to be making requests to the API is needed. For this reason, I have placed it in the ../EmployeePairFinder.Web/src/app/apiConfig.json file. Just change the value of the json property "baseUrl" to whatever base url is present when running the API(for example mine was "https://localhost:7288"), most likely the port number needs to be changed when you run it.

# Sidenote
I have added the cases for the algorithm that I have created to find the employee pairs that have worked the most on one project, alongside with a test data csv file.
