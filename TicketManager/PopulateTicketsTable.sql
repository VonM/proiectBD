DROP TABLE tickets;

CREATE TABLE tickets (
	Name varchar(255),
	FromUser varchar(255),
	ToUser varchar(255),
	Priority varchar(255),
	Department varchar(255),
	Category varchar(255),
	Description varchar(1000)
);

INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Description)
	VALUES ('Fix UI bug', 'dorin', 'madalin', 'High', 'Development', 'Bug', 'When a player closes a window, an exception is thrown. This must be fixed by handling the exception.');
INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Description)
	VALUES ('Handle employees payment this month', 'marin', 'andrei', 'Highest', 'Finance', 'Task', 'We have to pay our employees this month.');