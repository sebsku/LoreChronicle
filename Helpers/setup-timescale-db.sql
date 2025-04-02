-- Check if the "events" table exists before creating it
DO $$
BEGIN
    IF NOT EXISTS (SELECT FROM pg_tables WHERE schemaname = 'public' AND tablename = 'events') THEN
CREATE TABLE events (
                        event_id UUID NOT NULL,
                        event_type TEXT NOT NULL,
                        timestamp TIMESTAMPTZ NOT NULL,
                        duration INTERVAL NULL,
                        metadata JSONB,
                        PRIMARY KEY (event_id, timestamp)
);

-- Convert the table to a hypertable partitioned by timestamp
SELECT create_hypertable('events', 'timestamp');
END IF;
END $$;

-- Check if the "calendars" table exists before creating it
DO $$
BEGIN
    IF NOT EXISTS (SELECT FROM pg_tables WHERE schemaname = 'public' AND tablename = 'calendars') THEN
CREATE TABLE calendars (
                           calendar_id UUID PRIMARY KEY,
                           name TEXT NOT NULL,
                           description TEXT,
                           days_per_year INT NOT NULL,
                           months_per_year INT NOT NULL,
                           custom_era_names JSONB,
                           epoch_offset INT DEFAULT 0
);
END IF;
END $$;

-- Check if the "event_details" table exists before creating it
DO $$
BEGIN
    IF NOT EXISTS (SELECT FROM pg_tables WHERE schemaname = 'public' AND tablename = 'event_details') THEN
CREATE TABLE event_details (
                               event_detail_id UUID PRIMARY KEY,
                               event_id UUID REFERENCES events(event_id) ON DELETE CASCADE,
                               detail_type TEXT NOT NULL, -- e.g., 'Battle', 'Meeting', 'Discovery'
                               properties JSONB -- Stores type-specific properties
);
END IF;
END $$;

-- Check if the "entities" table exists before creating it
DO $$
BEGIN
    IF NOT EXISTS (SELECT FROM pg_tables WHERE schemaname = 'public' AND tablename = 'entities') THEN
CREATE TABLE entities (
                          entity_id UUID PRIMARY KEY,
                          entity_type TEXT NOT NULL,
                          name TEXT NOT NULL,
                          description TEXT,
                          metadata JSONB
);
END IF;
END $$;

-- Check if the "event_entity_relations" table exists before creating it
DO $$
BEGIN
    IF NOT EXISTS (SELECT FROM pg_tables WHERE schemaname = 'public' AND tablename = 'event_entity_relations') THEN
CREATE TABLE event_entity_relations (
                                        relation_id UUID PRIMARY KEY,
                                        event_id UUID REFERENCES events(event_id) ON DELETE CASCADE,
                                        entity_id UUID REFERENCES entities(entity_id) ON DELETE CASCADE,
                                        relation_type TEXT -- e.g., 'participant', 'location'
);
END IF;
END $$;

-- Check if the "calendars" table already exists before inserting an example record
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM calendars WHERE name = 'Default Calendar') THEN
        INSERT INTO calendars (calendar_id, name, description, days_per_year, months_per_year, custom_era_names, epoch_offset)
        VALUES 
        ('00000000-0000-0000-0000-000000000000', 'Default Calendar', 'A default calendar system', 365, 12, '{"era1": "Before Year 1", "era2": "After Year 1"}', 0);
END IF;
END $$;