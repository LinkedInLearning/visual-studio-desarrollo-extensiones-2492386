// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
const vscode = require('vscode');

// This method is called when your extension is activated
// Your extension is activated the very first time the command is executed

/**
 * @param {vscode.ExtensionContext} context
 */
function activate(context) {

	// Use the console to output diagnostic information (console.log) and errors (console.error)
	// This line of code will only be executed once when your extension is activated
	console.log('Congratulations, your extension "lil-extensiones" is now active!');

	let azurestatus = vscode.commands.registerCommand('azure-status', function () {
		const panel = vscode.window.createWebviewPanel('webPage', 'Estado de Azure',
		vscode.ViewColumn.Three,
		{ enableScripts: true }
	   );
	   panel.webview.html = getWebviewContent();
	});

	let insertguid = vscode.commands.registerCommand('insert-guid', function () {
		let editor = vscode.window.activeTextEditor;
		let selection = editor.selection;
		let selectionRange = new vscode.Range(selection.start.line, selection.start.character, selection.end.line, selection.end.character);

		editor.edit(eb => {
			eb.replace(selectionRange, uuidv4());
		});
	});

	context.subscriptions.push(azurestatus);
	context.subscriptions.push(insertguid);
}

// This method is called when your extension is deactivated
function deactivate() {}

function uuidv4() {
	return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
	.replace(/[xy]/g, function (c) {
		const r = Math.random() * 16 | 0,
			v = c == 'x' ? r : (r & 0x3 | 0x8);
		return v.toString(16);
	});
}

module.exports = {
	activate,
	deactivate
}

function getWebviewContent() {
    return `<!DOCTYPE html>
            <html lang="en">
            <head>
                <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
				<style>
				html, body, iframe {
					margin: 0;
					padding: 0;
					height: 100%;
					width: 100%;
					overflow: hidden;
					display: block;
				}
				</style>
                <title>Web Page</title>
            </head>
            <body>
                <iframe src="https://azure.status.microsoft"></iframe>
            </body>
            </html>`;
}