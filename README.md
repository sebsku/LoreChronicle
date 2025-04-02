# Lore Chronicle: App for managing chronicle of the lore


## Setup

## Database
This guide will help you set up the local database for **Lore Chronicle**. The database uses **TimescaleDB** for time-series data storage and **PostgreSQL** for type-specific event details.


### Prerequisites
- **Docker** and **Docker Compose** should be installed on your machine. If you don't have them yet, please follow these guides:
    - [Install Docker](https://docs.docker.com/get-docker/)
    - [Install Docker Compose](https://docs.docker.com/compose/install/)

### Setting up the TimeScale Database with Docker Compose

Follow these steps to set up the **TimescaleDB** container locally:

1. **Clone the repository** or download it to your local machine.

2. **Find the Docker Compose file**:
    - In the project root, navigate to `Helpers` directory inside you will find `timescale-docker-compose.yml`

3. **Change required properties:**
    - Modify file to set proper values for: `POSTGRES_USER, POSTGRES_PASSWORD`

4. **Start the TimescaleDB container**:
   - In the same directory where the `docker-compose.yml` file is located, run the following command to bring up the container:
   ```bash
    docker-compose up -d
   ```
   - This will download the timescale/timescaledb image, create the container, and expose port 5432 on your local machine to the TimescaleDB service.

5. **Stop the TimescaleDB container when you're done**:
    ```bash
   docker-compose down
   
### Setting up the Database Schema

After TimescaleDB is running, you need to set up the database schema for Lore Chronicle. Follow these steps:

1. **Find the SQL script**
    - - In the project root, navigate to `Helpers` directory inside you will find `setup-timescale-db.sql`
2. **Run the SQL script to set up the schema**
3. **Confirm that tables were created**

### Next steps TBD