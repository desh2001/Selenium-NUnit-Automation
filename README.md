# AssignmentProject — Selenium + NUnit UI Tests

Automated UI tests using Selenium WebDriver and NUnit targeting .NET 10. The suite exercises the "Alerts" scenarios on https://uitestingplayground.com and follows the Page Object Model for maintainability.

**Purpose:**
This project demonstrates best practices in **UI test automation** using **Visual Studio**, **Selenium**, and **NUnit**. It is designed for academic assignments and can be extended for professional web application testing projects.

## Key files and folders

- `AssignmentProject.Tests` — NUnit test classes (e.g. `AlertsTests.cs`).
- `AssignmentProject.Pages` — Page objects (e.g. `AlertsPage.cs`).
- `AssignmentProject.Utilities` — Helpers and `DriverManager` for browser lifecycle.

## Prerequisites

- .NET 10 SDK
- Google Chrome (compatible with the ChromeDriver used)
- Chromedriver available on `PATH` or use the `Selenium.WebDriver.ChromeDriver` NuGet package
- Recommended: Visual Studio 2026 for editing and debugging

## Setup

1. Clone the repository.
2. Restore packages: `dotnet restore`.
3. Ensure a compatible `chromedriver` is available.

## Running tests

- Run all tests: `dotnet test`.
- Run a single test by name: `dotnet test --filter TestName=TC004_4_Prompt_Accept`.
- Use Test Explorer in Visual Studio 2026 to run/debug individual tests.

## Debugging tips

- Set breakpoints in `Tests` or `Pages` and use the Visual Studio debugger.
- For alert dialogs, use `WebDriverWait` with `ExpectedConditions.AlertIsPresent()` and inspect `IAlert.Text` in the debugger when paused.
- The test suite normalizes alert text in some assertions (collapse whitespace, remove punctuation, lowercase) to reduce flakiness across environments. If strict formatting is required, update the expected strings in the test.

## Notes about recent test updates

- `AlertsTests` was updated to normalize prompt result text before asserting so the tests tolerate differences such as capitalization and punctuation (e.g. `"User value: CSE2522"` vs `"user value CSE2522"`). If you prefer exact-match behavior, change the assertions back to exact expected strings.

## Contributing

- Use branches, open pull requests for fixes/improvements.
- Keep tests deterministic and avoid brittle UI selectors.

## License

- Check with the project owner for licensing and reuse rules.
