DROP TABLE users;

CREATE TABLE users (
	Username varchar(255),
	Password varchar(256),
	Role varchar(255),
	Department varchar(255)
);

INSERT INTO users (Username, Password, Role, Department) VALUES ('madalin', 'B24DC91D476F3429292E6CD76B52D8E2281446E7330BF206EA0376BB1CAC56BD', 'Admin', 'Development');
INSERT INTO users (Username, Password, Role, Department) VALUES ('radu', 'E2561CB23FD849C14232C2897E231B00512F3B774A92E3134AE6E72ECDCF0AB7', 'Employee', 'Development');
INSERT INTO users (Username, Password, Role, Department) VALUES ('raul', '42A79148E647CCA5D0BECAC0C0B5845CB0C11D80525F1464D59D7BE0FEEEB4FB', 'Ticket_Editor', 'Development');
INSERT INTO users (Username, Password, Role, Department) VALUES ('andrei', 'B70C5216CA58902635529882E97C136069004E2E432C33CD6C7D0C96DD61E0D1', 'Employee', 'Finance');
INSERT INTO users (Username, Password, Role, Department) VALUES ('marin', '00E932BB37C1F7468CE66F7430567A7DB91984EBA26B27811C34D3644C6C1FFD', 'Ticket_Editor', 'Finance');
INSERT INTO users (Username, Password, Role, Department) VALUES ('cristi', 'EF58F2A7554D79F9A00B5522F5C2D437FA931AF97B05843EE030967730F5AED0', 'Employee', 'Marketing');
INSERT INTO users (Username, Password, Role, Department) VALUES ('mihai', 'EFACB25593CA596496451C9BB241E5071162812AB4DECD19EAA5A2E1F16F4385', 'Ticket_Editor', 'Marketing');
INSERT INTO users (Username, Password, Role, Department) VALUES ('dorin', '277B12C317720A0BA21BEB0FB7EB4C3BB44EBA7B32A3D98E97FC11FA20A4E2EA', 'Employee', 'Research_And_Development');
INSERT INTO users (Username, Password, Role, Department) VALUES ('catalin', '3A45209CD5E5FBC7C090A32FECF8CFA74C984E52CB074C2DB283EE6218EC387A', 'Ticket_Editor', 'Research_And_Development');
INSERT INTO users (Username, Password, Role, Department) VALUES ('andreea', '968EDCAD0FA54C281B3CD1FDFE2B026BA2DC12271508B1E8581366CE20FBCCD7', 'Employee', 'Human_Resources');
INSERT INTO users (Username, Password, Role, Department) VALUES ('mihaela', 'E393B684C25F5F364134F5CEAC428D42827CB4229F9A10A25F3B736FE28086A9', 'Ticket_Editor', 'Human_Resources');