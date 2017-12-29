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
	VALUES ('Fix UI bug', 'madalin', 'raul', 1, 'Development', 'Bug', '20120618 10:34:09 AM', 'Started', 'When a player closes a window an exception is thrown. This must be fixed by handling the exception.');
INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description)
	VALUES ('Handle employees payment this month', 'andrei', 'marin', 0, 'Finance', 'Task', '20120618 10:34:09 AM', 'Review', 'We have to pay our employees this month.');
INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description)
	VALUES ('Better market model', 'cristi', 'mihai', 1, 'Marketing', 'Feature', '20140601 10:34:15 AM', 'Started', 'We should consider using the Freemium model.');
INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description)
	VALUES ('New Machine Learning algorithm', 'dorin', 'catalin', 1, 'Research_And_Development', 'Story', '20170604 10:40:15 AM', 'Started', 'A great performance improvement in Neural Networks has been discovered.');
INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description)
	VALUES ('Upgrade computers', 'mihaela', 'madalin', 1, 'Human_Resources', 'Feature', '20130701 10:34:15 AM', 'Started', 'We need computers with better performance.');
INSERT INTO tickets (Name, FromUser, ToUser, Priority, Department, Category, Date, State, Description)
	VALUES ('Recruit new talent', 'andreea', 'mihaela', 3, 'Human_Resources', 'Story', '20130601 10:34:15 AM', 'Started', 'We could increase the number of our employees by searching and recruiting university students for summer internships.');

