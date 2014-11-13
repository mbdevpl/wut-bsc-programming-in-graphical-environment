#pragma once

#include "windows.h"

//global handles
HWND hWndMain = NULL;
HWND hWndBall = NULL;
HWND hWndCPU = NULL;
HWND hWndPlayer = NULL;
HWND hWndMimimizedPaint = NULL;

//global variables
int currKey = 0x41;
LPWSTR *allClasses = NULL;
int numOfClasses = 0;

//callback procedures
LRESULT CALLBACK WndProcMain(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
LRESULT CALLBACK WndProcRedLine(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
LRESULT CALLBACK WndProcPaddleCPU(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
LRESULT CALLBACK WndProcPaddlePlayer(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
LRESULT CALLBACK WndProcBall(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
BOOL CALLBACK enumWindowsProc(HWND hWnd, LPARAM lParam);

class WinApi {

private:
	
	//registers custom window class
	static ATOM defineWindowClass(HINSTANCE hInstance, WNDPROC wndProc, TCHAR windowClassName[], HBRUSH background) {
		WNDCLASSEX wcex;
		wcex.cbSize			= sizeof(WNDCLASSEX);
		wcex.style			= CS_HREDRAW | CS_VREDRAW;
		wcex.lpfnWndProc	= wndProc;
		wcex.cbClsExtra		= 0;
		wcex.cbWndExtra		= 0;
		wcex.hInstance		= hInstance;
		wcex.hIcon			= NULL;
		wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
		wcex.hbrBackground	= background;
		wcex.lpszMenuName	= NULL;
		wcex.lpszClassName	= windowClassName;
		wcex.hIconSm		= NULL;
		return RegisterClassEx(&wcex);
	}

	//initializes custom instance
	static BOOL initInstance(HINSTANCE hInstance, int nCmdShow, TCHAR szWindowClass[], TCHAR szTitle[], DWORD dwStyle,
			int x, int y, int width, int height, HWND parentWindow, bool alwaysStayOnTop = true){
		HWND hWnd;
		//hWnd = CreateWindow(szWindowClass, szTitle, dwStyle,
		//		x, y, width, height, parentWindow, NULL, hInstance, NULL);
		hWnd = CreateWindowEx(NULL, szWindowClass, szTitle, dwStyle, 
				x, y, width, height, parentWindow, NULL, hInstance, NULL);
		if (!hWnd) return FALSE;
		
		//if(parentWindow == NULL) mainWindow = hWnd;

		if(alwaysStayOnTop) {
			RECT rect;
			GetWindowRect(hWnd , &rect);

			::SetWindowPos(hWnd, HWND_TOPMOST, rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top, SWP_SHOWWINDOW);
		}

		ShowWindow(hWnd, nCmdShow);
		UpdateWindow(hWnd);

		return TRUE;
	}

public:
	
	static const int paddleHeight = 150;
	static const int paddleHalfHeight = 75;
	static const int paddleWidth = 30;
	static const int ballSize = 20;
	static const int ballHalfSize = 10;
	
	//defines all windows classes
	static void definePongWindowClasses(HINSTANCE hInstance) {
		defineWindowClass(hInstance, WndProcMain, L"MainWindow", (HBRUSH)(COLOR_WINDOW+1));
		defineWindowClass(hInstance, WndProcRedLine, L"RedLine", CreateSolidBrush( RGB(192, 0, 0) ));
		defineWindowClass(hInstance, WndProcPaddleCPU, L"PaddleCPU", CreateSolidBrush( RGB(192, 192, 192) ));
		defineWindowClass(hInstance, WndProcPaddlePlayer, L"PaddlePlayer", CreateSolidBrush( RGB(192, 192, 192) ));
		defineWindowClass(hInstance, WndProcBall, L"Ball", CreateSolidBrush( RGB(192, 192, 192) ));
		
		//numOfClasses = 5;
		//allClasses = new LPWSTR[5];
		//allClasses[0] = L"MainWindow";
		//allClasses[1] = L"RedLine";
		//allClasses[2] = L"PaddleCPU";
		//allClasses[3] = L"PaddlePlayer";
		//allClasses[4] = L"Ball";
		numOfClasses = 2;
		allClasses = new LPWSTR[2];
		allClasses[0] = L"Notepad";
		allClasses[1] = L"MSPaintApp";
	}

	static bool isClassCollected(LPWSTR className) {
		for(int i = 0; i < numOfClasses; i++) {
			std::wstring str1(allClasses[i]), 
					str2(className);
			if(str1.compare(str2) == 0)
				return true;
		}
		return false;
	}

	static void addClass(LPWSTR className) {
		LPWSTR *newAllClasses = new LPWSTR[numOfClasses+1];
		for(int i = 0; i < numOfClasses; i++)
			newAllClasses[i] = allClasses[i];
		numOfClasses++;
		newAllClasses[numOfClasses-1] = className;
		delete[] allClasses;
		allClasses = newAllClasses;
		
	}

	//initializes all windows
	static BOOL initPongInstances(HINSTANCE hInstance, int nCmdShow) {
		RECT rc;
		//GetWindowRect(GetDesktopWindow(), &rc);
		SystemParametersInfo(SPI_GETWORKAREA, NULL, &rc, NULL);

		if(! initInstance(hInstance, nCmdShow, L"MainWindow", L"Pong", WS_CAPTION | WS_SYSMENU,
				100, 100, 200, 100, NULL) )
			return FALSE;

		if(! initInstance(hInstance, nCmdShow, L"PaddleCPU", L"paddle of cpu", WS_POPUP | WS_VISIBLE | WS_DISABLED,
				rc.right - WinApi::paddleWidth, rc.bottom/2 - WinApi::paddleHalfHeight,
				WinApi::paddleWidth, WinApi::paddleHeight, hWndMain) )
			return FALSE;
		if(! initInstance(hInstance, nCmdShow, L"PaddlePlayer", L"paddle of cpu", WS_POPUP | WS_VISIBLE | WS_DISABLED,
				rc.left, rc.bottom/2 - WinApi::paddleHalfHeight,
				WinApi::paddleWidth, WinApi::paddleHeight, hWndMain) )
			return FALSE;

		if(! initInstance(hInstance, nCmdShow, L"Ball", L"the ball", WS_POPUP | WS_VISIBLE | WS_DISABLED,
				500, 500, WinApi::ballSize, WinApi::ballSize, hWndMain) )
			return FALSE;

		if(! initInstance(hInstance, nCmdShow, L"RedLine", L"lefthand side", WS_EX_TOPMOST | WS_POPUP | WS_VISIBLE | WS_DISABLED,
				rc.left + WinApi::paddleWidth, 0, 5, rc.bottom, hWndMain) )
			return FALSE;

		if(! initInstance(hInstance, nCmdShow, L"RedLine", L"righthand side", WS_POPUP | WS_VISIBLE | WS_DISABLED,
				rc.right - WinApi::paddleWidth - 5, 0, 5, rc.bottom, hWndMain) )
			return FALSE;

		return TRUE;
	}

	//paints main window (the one with caption etc.)
	static void paintMainWindow(HWND hWnd, HDC hdc, std::wstring wstr) {
		RECT wndRect, rectRed, rectGreen;
		GetClientRect(hWnd , &wndRect);
		HBRUSH hbrGreen = CreateSolidBrush(RGB(96, 196, 96));
		HBRUSH hbrRed = CreateSolidBrush(RGB(196, 0, 0));

		int margin = 20;
		rectRed.left = margin;
		rectRed.right = wndRect.right - margin;
		rectRed.top = margin;
		rectRed.bottom = wndRect.bottom - margin;
		FillRect(hdc, &rectRed, hbrRed);

		margin = 23;
		rectGreen.left = margin;
		rectGreen.right = wndRect.right - margin;
		rectGreen.top = margin;
		rectGreen.bottom = wndRect.bottom - margin;
		FillRect(hdc, &rectGreen, hbrGreen);
		
		margin = 27;
		drawString(hdc, margin, margin, wstr);

        DeleteObject(hbrGreen);
        DeleteObject(hbrRed);
	}
	
	static void drawString(HDC hdc, int x, int y, std::wstring wstr) {
		TextOut(hdc, x, y, wstr.c_str(), wstr.length());
	}

};

LRESULT CALLBACK WndProcMain(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {
	switch (message) {
		//case 

		case WM_CREATE: {
			hWndMain = hWnd;
		} break;

		case WM_TIMER: {
			if(hWndMimimizedPaint != NULL) {
				SendMessage(hWndMimimizedPaint, WM_SYSCOMMAND, SC_RESTORE, NULL);
				hWndMimimizedPaint = NULL;
				//SetActiveWindow(hWndMain);
				SetForegroundWindow(hWndMain);
				KillTimer(hWnd, NULL);
			}
		} break;

		case WM_PAINT: {
			PAINTSTRUCT ps;
			HDC hdc;
			hdc = BeginPaint(hWnd, &ps);
			WinApi::paintMainWindow(hWnd, hdc, p.getScore());
			EndPaint(hWnd, &ps);
		} break;

		case WM_KEYDOWN: {
			if(wParam == VK_UP || wParam == VK_DOWN) {
				SendMessage(hWndPlayer, message, wParam, lParam);
			} else
				return DefWindowProc(hWnd, message, wParam, lParam);
		} break;
		
		case WM_KEYUP: {
			if(wParam == VK_UP || wParam == VK_DOWN) {
				SendMessage(hWndPlayer, message, wParam, lParam);
			} else
				return DefWindowProc(hWnd, message, wParam, lParam);
		} break;

		case WM_DESTROY: {
			PostQuitMessage(0);
		} break;

		default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

//window procedure for the red line
LRESULT CALLBACK WndProcRedLine(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {
	return DefWindowProc(hWnd, message, wParam, lParam);
}

//window procedure for CPU's paddle
LRESULT CALLBACK WndProcPaddleCPU(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {
	switch (message) {
		case WM_CREATE: {
			SetTimer(hWnd, NULL, 30, NULL);
			hWndCPU = hWnd;
		} break;

		case WM_TIMER: {
			RECT ball, wnd, scr;
			int ballMiddle, paddleMiddle, yModif;

			yModif = 0;
			GetWindowRect(hWndBall, &ball);
			GetWindowRect(hWnd, &wnd);
			//GetWindowRect(GetDesktopWindow(), &scr);
			SystemParametersInfo(SPI_GETWORKAREA, NULL, &scr, NULL);
			ballMiddle = ball.top + WinApi::ballHalfSize;
			paddleMiddle = wnd.top + WinApi::paddleHalfHeight;

			if(paddleMiddle > ballMiddle && wnd.top + Pong::cpuPaddleSpeed >= Pong::cpuPaddleSpeed)
				yModif = -Pong::cpuPaddleSpeed;
			else if(paddleMiddle < ballMiddle && wnd.bottom + Pong::cpuPaddleSpeed <= scr.bottom - Pong::cpuPaddleSpeed)
				yModif = Pong::cpuPaddleSpeed;

			MoveWindow(hWnd, wnd.left, wnd.top + yModif, wnd.right - wnd.left, wnd.bottom - wnd.top, TRUE);
			
		} break;

		case WM_DESTROY: {
			KillTimer(hWnd, NULL);
			PostQuitMessage(0);
		} break;
		
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

//window procedure for player's paddle
LRESULT CALLBACK WndProcPaddlePlayer(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {
	switch (message) {
		case WM_CREATE: {
			SetTimer(hWnd, NULL, 30, NULL);
			hWndPlayer = hWnd;
		} break;

		case WM_TIMER: {
			RECT wnd, scr;
			GetWindowRect(hWnd, &wnd);
			//GetWindowRect(GetDesktopWindow(), &scr);
			SystemParametersInfo(SPI_GETWORKAREA, NULL, &scr, NULL);
			if((wnd.top - Pong::playerPaddleSpeed < 0 && p.getPlayerWill() < 0)
					|| (wnd.bottom + Pong::playerPaddleSpeed > scr.bottom && p.getPlayerWill() > 0))
				p.setPlayerWillNone();
			MoveWindow(hWnd, wnd.left, wnd.top + p.getPlayerWill(), wnd.right - wnd.left, wnd.bottom - wnd.top, TRUE);
		} break;
		
		case WM_KEYDOWN: {
			RECT wnd, scr;

			if(wParam == VK_UP) {
				GetWindowRect(hWnd, &wnd);
				GetWindowRect(GetDesktopWindow(), &scr);
				if(wnd.top - Pong::playerPaddleSpeed >= 0)
					p.setPlayerWillUp();
				else p.setPlayerWillNone();
				
			} else if(wParam == VK_DOWN) {
				GetWindowRect(hWnd, &wnd);
				GetWindowRect(GetDesktopWindow(), &scr);
				if(wnd.bottom + Pong::playerPaddleSpeed <= scr.bottom)
					p.setPlayerWillDown();
				else p.setPlayerWillNone();
			} else
				return DefWindowProc(hWnd, message, wParam, lParam);
		} break;

		case WM_KEYUP: {
			if(wParam == VK_UP || wParam == VK_DOWN) {
				p.setPlayerWillNone();
			} else
				return DefWindowProc(hWnd, message, wParam, lParam);
		} break;

		case WM_DESTROY: {
			KillTimer(hWnd, NULL);
			PostQuitMessage(0);
		} break;
		
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

//window procedure for ball
LRESULT CALLBACK WndProcBall(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {
	switch (message) {
		case WM_CREATE: {
			SetTimer(hWnd, NULL, 20, NULL);
			hWndBall = hWnd;
		} break;

		case WM_TIMER: {
			RECT wnd, scr, cpu, play;
			bool turnEnds = false;
			int yModif = 0, xModif = 0;
			GetWindowRect(hWnd, &wnd);
			
			GetWindowRect(hWndCPU, &cpu);
			if(cpu.left <= wnd.right && (cpu.top >= wnd.bottom || cpu.bottom <= wnd.top)) {
					p.incScorePlayer();
				turnEnds = true;
			} else {
				GetWindowRect(hWndPlayer, &play);
				if(play.right >= wnd.left && (play.top >= wnd.bottom || play.bottom <= wnd.top)) {
					p.incScoreCPU();
					turnEnds = true;
				}
			}
			
			//GetWindowRect(GetDesktopWindow(), &scr);
			SystemParametersInfo(SPI_GETWORKAREA, NULL, &scr, NULL);
			if(turnEnds) {
				MoveWindow(hWnd, 400 + rand() % (wnd.right - 500), rand() % (scr.bottom - wnd.bottom + wnd.top),
						wnd.right - wnd.left, wnd.bottom - wnd.top, TRUE);
				InvalidateRect(hWndMain, NULL, TRUE);
				UpdateWindow(hWndMain);

			} else {
				if( !EnumWindows(enumWindowsProc, NULL) ) {
					KillTimer(hWnd, NULL);
				}
				
				//workarea border collisions are superior to collisions with other windows
				if(wnd.top <= scr.top)
					p.setBallMovingUp(false);
				else if(wnd.bottom >= scr.bottom)
					p.setBallMovingUp(true);
				if(wnd.left <= scr.left + WinApi::paddleWidth)
					p.setBallMovingLeft(false);
				else if(wnd.right >= scr.right - WinApi::paddleWidth)
					p.setBallMovingLeft(true);


				if(p.isBallMovingUp()) yModif = -Pong::ySpeed;
				else yModif = Pong::ySpeed;
				if(p.isBallMovingLeft()) xModif = -Pong::xSpeed;
				else xModif = Pong::xSpeed;

				MoveWindow(hWnd, wnd.left + xModif, wnd.top + yModif, wnd.right - wnd.left, wnd.bottom - wnd.top, TRUE);
			}
		} break;

		case WM_DESTROY: {
			KillTimer(hWnd, NULL);
			PostQuitMessage(0);
		} break;

		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

BOOL CALLBACK enumWindowsProc(HWND hWnd, LPARAM lParam) {
	if(hWnd == NULL) return FALSE;
	WCHAR className[64];
	GetClassName(hWnd, className, 64);

	//if(! WinApi::isClassCollected(className)) {
	//	WinApi::addClass(className);
	//	if( numOfClasses < 20 ) {
	//		std::wstring s(L"All classes so far:");
	//		for(int i = 0; i < numOfClasses; i++) {
	//			s.append(L"\n");
	//			s.append(allClasses[i]);
	//		}
	//		MessageBox(hWndMain, s.c_str(), L"Window classes list" , NULL);
	//	}
	//}

	if(WinApi::isClassCollected(className)) {
		std::wstring wstr(className), notepad(allClasses[0]), paint(allClasses[1]);

		if(wstr.compare(notepad) == 0 || wstr.compare(paint) == 0) {
			RECT ball, note;
			bool collision = false;
			GetWindowRect(hWnd, &note);
			GetWindowRect(hWndBall, &ball);

			//top & bottom collisions
			if(ball.left <= note.right && ball.right >= note.left && ball.top <= note.bottom && ball.bottom > note.bottom) {
				p.setBallMovingUp(false);
				collision = true;
			} else if(ball.left <= note.right && ball.right >= note.left && ball.bottom >= note.top && ball.top < note.top) {
				p.setBallMovingUp(true);
				collision = true;
			} else if(ball.top <= note.bottom && ball.bottom >= note.top) { //left & right collisions
				if(ball.left <= note.right && ball.right > note.right) {
					p.setBallMovingLeft(false);
					collision = true;
				} else if(ball.right >= note.left && ball.left < note.left) {
					p.setBallMovingLeft(true);
					collision = true;
				} 
			}
			
			if(collision) {
				if(wstr.compare(notepad) == 0) {
					//noteID = GetWindowThreadProcessId(hWnd, NULL);
					//mainID = GetWindowThreadProcessId(hWndMain, NULL);
					//if( !AttachThreadInput(noteID, mainID, TRUE) ) return FALSE;
					//MessageBox(hWndMain, L"Comment: winapi sucks.", L"Bad error" , NULL);
					
					DWORD noteID, mainID;
					int i;
					WCHAR title[64];

					GetWindowText(hWnd, title, 64);
					SetForegroundWindow(hWnd);
					SetFocus(hWnd);
					SetWindowText(hWnd, title);
					
					/*INPUT inp;
					KEYBDINPUT kinp;
					kinp.dwFlags = 0;
					kinp.time = 0;
					kinp.wVk = 0x41;
					kinp.dwExtraInfo = 0;
					inp.type = INPUT_KEYBOARD;
					inp.ki = kinp;
					SendInput(1, &inp, sizeof(INPUT));*/
					
					INPUT input[4];
					memset(input, 0, sizeof(input));
					i = 0;
					input[i].type = INPUT_KEYBOARD;
					input[i].ki.wVk = VK_SHIFT;
					input[i].ki.dwFlags = 0;
					input[i].ki.time = 0;
					input[i].ki.dwExtraInfo = 0;

					i = 1;
					input[i].type = INPUT_KEYBOARD;
					input[i].ki.wVk = currKey;
					input[i].ki.dwFlags = 0;
					input[i].ki.time = 0;
					input[i].ki.dwExtraInfo = 0;

					i = 2;
					input[i].type = INPUT_KEYBOARD;
					input[i].ki.wVk = currKey;
					input[i].ki.dwFlags = KEYEVENTF_KEYUP;
					input[i].ki.time = 0;
					input[i].ki.dwExtraInfo = 0;
					
					i = 3;
					input[i].ki.wVk = VK_SHIFT;
					input[i].ki.dwFlags = KEYEVENTF_KEYUP;
					input[i].ki.time = 0;
					input[i].ki.dwExtraInfo = 0;

					SendInput(4, input, sizeof(INPUT));

					SetForegroundWindow(hWndMain);
					SetFocus(hWndMain);

					currKey++;
					if(currKey > 0x5A) currKey = 0x41;

					//SendMessage(hWnd, WM_KEYDOWN, 0x41, NULL);
					//SendMessage(hWnd, WM_KEYUP, 0x41, NULL);
					//if( !AttachThreadInput(noteID, mainID, FALSE) ) return FALSE;
					//MessageBox(hWndMain, L"Comment: you don't understand winapi at all.", L"Bad error" , NULL);

				} else if(wstr.compare(paint) == 0) {
					SendMessage(hWnd, WM_SYSCOMMAND, SC_MINIMIZE, NULL);
					hWndMimimizedPaint = hWnd;
					SetForegroundWindow(hWndMain);
					SetTimer(hWndMain, NULL, 3000, NULL);

				}
			}
		}
	}

	return TRUE;
}
