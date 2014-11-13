// Programming4 Lab01
// Mateusz Bysiek

#pragma once

#include "windows.h"
#include "Pong.h"
#include "WinApi.h"

int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPTSTR lpCmdLine, int nCmdShow) {
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);
	
	//initialization
	WinApi::definePongWindowClasses(hInstance);
	if( !WinApi::initPongInstances(hInstance, nCmdShow) )
		return FALSE;
	
	//message loop
	MSG msg;
	while (GetMessage(&msg, NULL, 0, 0)) {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return (int)msg.wParam;
}
