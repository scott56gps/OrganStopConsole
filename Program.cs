using OrganStopConsole.UI;
using OrganStopConsole.UI.Screens;
using OrganStopConsole.UI.ViewModels;

var pieceViewModel = new PieceSelectViewModel();
var summaries = await pieceViewModel.GetPieceSummaries();

var navigator = new Navigator();
navigator.Push(new PieceSelectScreen(summaries));
await navigator.Run();
