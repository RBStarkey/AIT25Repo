function copyTextToClipboard(text) {
	navigator.clipboard.writeText(text).then(function () {
		console.log('Text copied to clipboard, chars: ' + text.length);
		alert("The text is on the clipboard.  You can paste it by pressing CTRL + V");
	}).catch(function (err) {
		console.error('Could not copy text: ', err);
	});
}