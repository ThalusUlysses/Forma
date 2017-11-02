# Forma
Forma is a small parsing and formatting library for double, int, char and string with meta parameters as CSV or JSON.
Forma comes from latin and means by far format or formatting. With Forma you are able to create parser and formatters
for your need.

#Example

For example a command like `MYCOMMAND 1,23.5,"The Command",'c'` will be parsed to a structure like:
```
{
	"Parts": [{
			"Value": 1,
			"Meta": null,
			"Unit": null,
			"Type": "int-param",
			"Id": "MYCOMMAND-1"
		}, {
			"Value": 23.5,
			"Meta": {
				"Default": 0.0,
				"Precision": 1,
				"Ranges": null,
				"Enum": null,
				"DisplayText": null,
				"Type": "double-meta",
				"Id": "MYCOMMAND-2-meta"
			},
			"Unit": null,
			"Type": "double-param",
			"Id": "MYCOMMAND-2"
		}, {
			"Value": "The Command",
			"Meta": null,
			"Unit": null,
			"Type": "string-param",
			"Id": "MYCOMMAND-3"
		}, {
			"Value": "c",
			"Meta": null,
			"Unit": null,
			"Type": "char-param",
			"Id": "MYCOMMAND-4"
		}
	],
	"Meta": null,
	"Type": "group",
	"Id": "MYCOMMAND"
}
```
