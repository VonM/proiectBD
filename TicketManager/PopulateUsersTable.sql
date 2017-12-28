DROP TABLE users;

CREATE TABLE users (
	Username varchar(255),
	Password varchar(255),
	Role varchar(255),
	Department varchar(255)
);

INSERT INTO users (Username, Password, Role) VALUES ('madalin', 'passmadalin', 'Admin', 'Development');
INSERT INTO users (Username, Password, Role) VALUES ('andrei', 'passandrei', 'Employee', 'Finance');
INSERT INTO users (Username, Password, Role) VALUES ('marin', 'passmarin', 'Employee', 'Finance');
INSERT INTO users (Username, Password, Role) VALUES ('cristi', 'passcristi', 'Employee', 'Marketing');
INSERT INTO users (Username, Password, Role) VALUES ('dorin', 'passdorin', 'Ticket_Editor', 'Research_And_Development');
INSERT INTO users (Username, Password, Role) VALUES ('vasile', 'passvasile', 'Ticket_Editor', 'Human_Resources');