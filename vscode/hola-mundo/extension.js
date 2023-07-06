const vscode = require('vscode');

/**
 * @param {vscode.ExtensionContext} context
 */
function activate(context) {

	console.log('Congratulations, your extension "hola-mundo" is now active!');

	let disposable = vscode.commands.registerCommand('hola-mundo', function () {
		vscode.window.showInformationMessage('¡Hola LinkedIn Learning!');
	});

	context.subscriptions.push(disposable);
}

function deactivate() {}

module.exports = {
	activate,
	deactivate
}