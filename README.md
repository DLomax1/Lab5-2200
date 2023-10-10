# Lab5-2200
# Rick and Morty Info Viewer

This is a C# Console Application that allows users to interact with the Rick and Morty API to retrieve and display information about characters, episodes, and locations from the animated TV series "Rick and Morty."

## Issues Encountered and Solutions

### Issue 1: Unable to Retrieve Character Information

- **Description**: When attempting to retrieve character information, the application displayed an error message.
- **Steps Taken**: 
  - Checked the API endpoint URL for character information.
  - Verified that the character ID provided by the user was valid.
  - Examined the JSON response from the API for any error messages.
- **Outcome**: The issue was resolved by updating the URL path to the correct API endpoint for character information. It was discovered that the character ID was being passed correctly, but the URL format was incorrect.

### Issue 2: Improved Error Handling

- **Description**: The application displayed generic error messages without details, making it challenging for users to understand issues.
- **Steps Taken**: 
  - Implemented structured error handling to provide more informative error messages.
  - Created custom error messages for scenarios such as invalid inputs, network errors, and API-related issues.
- **Outcome**: Users now receive descriptive error messages that help them understand and address issues when they occur.

### Issue 3: Enhancing User Input Validation

- **Description**: Users were able to enter invalid character IDs, causing unexpected behavior.
- **Steps Taken**: 
  - Improved user input validation to ensure that character IDs entered are positive integers.
  - Provided clear guidance to the user on valid input.
- **Outcome**: The application now validates user input and prevents invalid character IDs from being processed.

## Usage

To use this application, follow these steps:

1. Clone the repository to your local machine.
2. Open the project in Visual Studio 
3. Build and run the application.
4. Follow the on-screen menu to select options for viewing character, episode, or location information.

## Credits

- Devin Lomax
