# .NET Essentials - Logging in .NET

This repository contains the demo project discussed in Betatalks episodes #95 and #96. In these talks, we explore various aspects of logging in .NET, including logger messages, log properties, tag providers, redactors, and enrichers.

This demo project is an integral part of the two-part episode about Logging in .NET, hosted on YouTube. Make sure to watch these episodes to better understand the source code:
- [Betatalks #95 - .NET Essentials - Logging (Part 1)](https://youtu.be/sK8WK_I9VYs)
- Betatalks #96 - .NET Essentials - Logging (Part 2) (coming soon)

For more topics about Software Development in .NET & Azure, check out the entire [Betatalks playlist](https://www.youtube.com/playlist?list=PLCLCtgDNNiJR_LDx6RT8X50VrKAH3_49B) available on YouTube.

## Overview

Logging is an essential aspect of any software application as it helps in understanding application behavior, debugging issues, and monitoring performance. In the .NET ecosystem, logging is facilitated by various frameworks such as Serilog, NLog, and Microsoft.Extensions.Logging.

This project serves as a demonstration of best practices and essential techniques for effective logging in .NET applications using Microsoft.Extensions.Logging.

## Features

- **Logger Messages**: Demonstrates how to create log messages using different severity levels (e.g., Information, Warning, Error) and structured logging.
- **Log Properties**: Shows how to attach additional properties or metadata to log messages for better categorization and analysis.
- **Tag Providers**: Illustrates the use of tag providers to dynamically enrich log messages with contextual information.
- **Redactors**: Explores techniques for redacting sensitive information from log messages to maintain data privacy.
- **Enrichers**: Demonstrates how enrichers can automatically add contextual information to log messages (e.g., timestamps, machine information).

## Getting Started

To get started with this project, follow these steps:

1. Clone this repository to your local machine:

```bash
git clone https://github.com/steven-hack/DotNetEssentials.Logging.git
```

2. Navigate to the project directory:

```bash
cd DotNetEssentials.Logging
```

3. Open the solution in your preferred IDE or text editor.

4. Explore the minimal API endpoints defined in [Program.cs](Program.cs).

## Requirements

- .NET SDK (version 8.0 or later)
- [Optional] IDE or text editor (e.g., Visual Studio, Visual Studio Code)

## Usage

Feel free to use the code provided in this repository as a reference or starting point for implementing logging in your .NET applications. Each feature or technique is well-documented within the codebase to facilitate understanding and adaptation.

## Contributing

Contributions to this project are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For any questions or inquiries about this project, feel free to contact [Steven Hack](mailto:s.hack@betabit.nl).

Enjoy logging in .NET! 🚀
