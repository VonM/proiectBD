DROP TABLE users;

CREATE TABLE users (
	Username varchar(255),
	Password varchar(256),
	Role varchar(255),
	Department varchar(255)
);

INSERT INTO users (Username, Password, Role, Department) VALUES ('madalin', '28E4DD049D9AADB6A0CBCC5798F3BE4A87EBD8754CBE1C0A8D89F27B27E9D64B', 'Admin', 'Development');
INSERT INTO users (Username, Password, Role, Department) VALUES ('andrei', 'B70C5216CA58902635529882E97C136069004E2E432C33CD6C7D0C96DD61E0D1', 'Employee', 'Finance');
INSERT INTO users (Username, Password, Role, Department) VALUES ('marin', '00E932BB37C1F7468CE66F7430567A7DB91984EBA26B27811C34D3644C6C1FFD', 'Employee', 'Finance');
INSERT INTO users (Username, Password, Role, Department) VALUES ('cristi', 'EF58F2A7554D79F9A00B5522F5C2D437FA931AF97B05843EE030967730F5AED0', 'Employee', 'Marketing');
INSERT INTO users (Username, Password, Role, Department) VALUES ('dorin', '277B12C317720A0BA21BEB0FB7EB4C3BB44EBA7B32A3D98E97FC11FA20A4E2EA', 'Ticket_Editor', 'Research_And_Development');
INSERT INTO users (Username, Password, Role, Department) VALUES ('vasile', '224FC9B678DE0EE4F719E0B06053E523C30F9C2EDE629322679C47264B58E72D', 'Ticket_Editor', 'Human_Resources');
INSERT INTO users (Username, Password, Role, Department) VALUES ('cosmin', '66900B2138C834926F16A01E7EEEEE82865332B6D9089B8F7058BF952CC71631', 'Employee', 'Human_Resources');