
-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );


-- CREATE TABLE restaurants
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   ownerId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   location VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (ownerId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE
-- );



-- CLEAN DATA OUT OF TABE WITH TRUNCATE
-- TRUNCATE TABLE restaurants;


-- CREATE TABLE reviews
-- (
-- id INT NOT NULL AUTO_INCREMENT,
-- title VARCHAR(255) NOT NULL,
-- body VARCHAR(255) NOT NULL,
-- published TINYINT NOT NULL,
-- restaurantId INT NOT NULL,
-- rating INT CHECK (rating >= 0 AND rating < 6),
-- ownerId VARCHAR(255) NOT NULL,

-- PRIMARY KEY (id),

--   FOREIGN KEY (ownerId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE,

--   FOREIGN KEY (restaurantId)
--    REFERENCES restaurants (id)
--    ON DELETE CASCADE
-- );



