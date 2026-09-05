I want to learn AI Agent development by building a small practical project.

Build a beginner-friendly project called **AI Project Impact Analysis / Bag Management System** using the following architecture:

User Chat → Orchestration Layer → Confluence Search Tool → Confluence.json → Impact Analysis → LLM → Final Response.

I want to implement this step by step.

### Requirements

1. Create a `Confluence.json` file containing project information.
   Each document should have:

   * title
   * content

2. Create a Confluence Search Tool.
   The tool should:

   * Load `Confluence.json`
   * Accept a user query
   * Search the query against title and content
   * Return all matching documents
   * Return the complete document content for each match

3. Create an Agent/Function Tool definition for the Confluence Search Tool.

4. Create an Orchestration Layer.
   Implement a method such as:
   `ProcessUserQuery(string chat)`

5. The orchestration layer should:

   * Receive the user's chat/query
   * Call the Confluence Search Tool
   * Collect the matching project information
   * Send the retrieved information together with the user's query to the LLM

6. The LLM should perform impact analysis.

For example, if the user asks:

"How much money will an inventory-related project cost?"

The system should search the available project information, identify relevant projects, compare their costs and technologies, and provide a reasonable estimate based only on the retrieved information.

7. Explain the complete execution flow.

8. Provide production-style code using C# and .NET.

9. Keep the first version very small and simple. Do not introduce a vector database initially. Use JSON-based search first.

10. After completing the basic version, explain how we could upgrade it to:

    * Real Confluence API
    * Embeddings
    * Vector database
    * RAG
    * Multiple Agent Tools
    * Azure OpenAI
    * Production deployment

### Teaching style

I am learning this from scratch, so explain every step.

For every step provide:

* What we are building
* Why we need it
* Folder/file structure
* Code
* How the code works
* Example input
* Example output
* How it connects to the next step

Do not give the entire project at once.

Start with **Step 1: Create the project and Confluence.json**, then wait for me to say **NEXT** before moving to Step 2.
