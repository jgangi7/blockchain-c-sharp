# C# Blockchain API

A simple blockchain implementation in C# using ASP.NET Core Web API.
-----------------------
-----------------------
## Features

- Block creation and mining with proof-of-work
- Chain validation
- RESTful API endpoints
- Swagger UI for API documentation and testing
-----------------------
-----------------------
## Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
-----------------------
-----------------------
## Getting Started

1. Clone the repository
2. Navigate to the project directory
3. Run the application:
   dotnet run
4. Open your browser and navigate to `https://localhost:7042/swagger` to access the Swagger UI

## API Endpoints

    ### GET /api/blockchain/blocks
        Returns the entire blockchain.

    ### POST /api/blockchain/mine
        Mines a new block with the provided data.

        Request body: JSON string with the block data

        Example:
        json: { "Transaction data here" }

    ### GET /api/blockchain/validate
    ^Validates the integrity of the blockchain.

    ## Implementation Details

    - Each block contains: Index, Timestamp, Previous Hash, Hash, Data, and Nonce
    - Proof-of-work difficulty is set to 2 (can be adjusted in the Blockchain class)
    - SHA256 hashing is used for block hashes
    - Chain validation checks both block hashes and chain integrity 
-----------------------
-----------------------
## Running the C# Blockchain API

## Prerequisites
1. Install .NET 8.0 SDK 
2. Any code editor (Visual Studio Code recommended)
-----------------------
## Steps to Run

1. Open a terminal/command prompt and navigate to the BlockchainApi directory:
cd BlockchainApi

2. Restore the NuGet packages:
dotnet restore

3. Run the application:
dotnet run

4. The API will start running and will be available at:
   - HTTP: http://localhost:5219
   - Swagger UI: http://localhost:5219/swagger
-----------------------
-----------------------
## Testing the API

You can test the API using either UI or any HTTP client (like Postman):

(I personally like postman for this)

### Using UI
1. Open your browser and navigate to http://localhost:5219/swagger
2. You'll see three endpoints:
   - GET /api/blockchain/blocks
   - POST /api/blockchain/mine
   - GET /api/blockchain/validate

### Using Curl or Postman

1. View the blockchain:
curl http://localhost:5219/api/blockchain/blocks

2. Mine a new block:
curl -X POST http://localhost:5219/api/blockchain/mine \
     -H "Content-Type: application/json" \
     -d "\"My first transaction\""

3. Validate the blockchain:
curl http://localhost:5219/api/blockchain/validate
