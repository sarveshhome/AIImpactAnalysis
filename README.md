# AI Project Impact Analysis / Bag Management System

A beginner-friendly AI Agent project built with C# and .NET to learn AI agent development through a practical, step-by-step implementation.

## Architecture

```
User Chat → Orchestration Layer → Confluence Search Tool → Confluence.json → Impact Analysis → LLM → Final Response
```

## What This Project Does

This application demonstrates how to build an AI-powered impact analysis system. Given a user's natural language query (e.g., *"How much money will an inventory-related project cost?"*), the system:

1. Searches a local JSON-based knowledge base (`Confluence.json`) for relevant project documents
2. Retrieves matching project information based on title and content similarity
3. Sends the retrieved context along with the user's query to an LLM
4. Returns an AI-generated impact analysis based solely on the retrieved data

## Tech Stack

- **Framework:** .NET 10.0
- **Language:** C# with nullable reference types and implicit usings
- **API:** OpenAPI (Swagger) support
- **LLM Integration:** Designed for Azure OpenAI / OpenAI API integration
- **Knowledge Base:** JSON-based document store (`Confluence.json`)

## Project Structure

```
AIImpactAnalysis/
├── Program.cs                          # Application entry point and API endpoints
├── AIImpactAnalysis.csproj             # Project file with dependencies
├── appsettings.json                    # Application configuration
├── appsettings.Development.json        # Development environment settings
├── Properties/
│   └── launchSettings.json             # Launch profiles for debugging
├── bin/                                # Build output
├── obj/                                # Build artifacts
└── README.md                           # This file
```

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Running the Application

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

Once running, the API will be available at `https://localhost:5001` (or the port configured in `launchSettings.json`).

### OpenAPI Documentation

When running in Development mode, OpenAPI/Swagger documentation is automatically available at:
```
https://localhost:5001/openapi/v1.json
```

## Learning Path

This project is designed for step-by-step learning. The implementation follows these stages:

1. **Project Setup & Confluence.json** - Create the project structure and JSON knowledge base
2. **Confluence Search Tool** - Build a tool to search documents by title and content
3. **Agent/Function Tool Definition** - Define the search tool for AI agent consumption
4. **Orchestration Layer** - Implement the `ProcessUserQuery` method to coordinate the workflow
5. **LLM Integration** - Connect to an LLM for impact analysis
6. **Production Enhancements** - Upgrade to real Confluence API, embeddings, vector database, RAG, and Azure OpenAI

## Current State

This is the initial project scaffold with a basic weather forecast API endpoint. The AI Impact Analysis features are being built incrementally following the requirements outlined in `PR.md`.

---
<img width="2988" height="1654" alt="image" src="https://github.com/user-attachments/assets/54af6ad0-6996-46d0-8884-c59fd426ae84" />

---

## Contributing

This is a learning project. Feel free to explore, experiment, and extend the implementation.

## License

MIT
