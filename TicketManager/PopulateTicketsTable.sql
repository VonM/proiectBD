DROP TABLE tickets;

CREATE TABLE tickets (
	Name varchar(255),
	FromUser varchar(255),
	ToUser varchar(255),
	Priority int,
	Department varchar(255),
	Category varchar(255),
	Date datetime,
	State varchar(255),
	Description varchar(1000)
);

INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description)
	VALUES ('Fix UI bug', 'dorin', 'madalin', 1, 'Development', 'Bug', '20120618 10:34:09 AM', 'Started', 'When a player closes a window, an exception is thrown. This must be fixed by handling the exception.');
INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description)
	VALUES ('Handle employees payment this month', 'marin', 'andrei', 0, 'Finance', 'Task', '20120618 10:34:09 AM', 'Review', 'We have to pay our employees this month.');
INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description)
	VALUES ('Upgrade computers', 'madalin', 'cristi', 1, 'Marketing', 'Feature', '20120601 10:34:15 AM', 'Started', 'We need computers with better performance.');
