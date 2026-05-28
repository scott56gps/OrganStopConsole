using OrganStopConsole.Service;
using OrganStopConsole.UI;
using OrganStopConsole.UI.Screens;

var pieceService = new PieceService(new NetworkClient());
var pieces = await pieceService.GetPieces();

var navigator = new Navigator();
navigator.Push(new PieceSelectScreen(pieces));
await navigator.Run();
