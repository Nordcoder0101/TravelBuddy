DROP SCHEMA IF EXISTS TravelBuddy;

CREATE SCHEMA IF NOT EXISTS TravelBuddy;

USE TravelBuddy;

CREATE TABLE users (
  user_id     INTEGER       NOT NULL  AUTO_INCREMENT PRIMARY KEY,
  first_name  VARCHAR(255)  NOT NULL,
  last_name   VARCHAR(255)  NOT NULL,
  email       VARCHAR(255)  NOT NULL,
  password    VARCHAR(255)  NOT NULL
);

CREATE TABLE trips (
  trip_id     INTEGER       NOT NULL  AUTO_INCREMENT  PRIMARY KEY,
  user_id     INTEGER      NOT NULL,
  name        VARCHAR(255) NOT NULL,
  start_date  DATETIME     NOT NULL,
  end_date    DATETIME     NOT NULL,

  FOREIGN KEY (user_id)
    REFERENCES users(user_id)
);

CREATE TABLE days (
  day_id      INTEGER     NOT NULL  AUTO_INCREMENT  PRIMARY KEY,
  date        DATETIME    NOT NULL,
  trip_id     INTEGER     NOT NULL,

  FOREIGN KEY (trip_id)
    REFERENCES trips(trip_id)
);

CREATE TABLE flights (
  flight_id       INTEGER       NOT NULL  AUTO_INCREMENT  PRIMARY KEY,
  day_id          INTEGER       NOT NULL,
  airline_name    VARCHAR(255)  NOT NULL,
  flight_number   VARCHAR(255)  NOT NULL,
  departure_date  DATETIME      NOT NULL,
  arrival_date    DATETIME      NOT NULL,
  departing_city  VARCHAR(255)  NOT NULL,
  departing_state VARCHAR(255)  NOT NULL,
  arrival_city    VARCHAR(255)  NOT NULL,
  arrival_state   VARCHAR(255)  NOT NULL,
  
  FOREIGN KEY (day_id)
    REFERENCES days(day_id)
);