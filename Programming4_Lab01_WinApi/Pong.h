#pragma once

#include <time.h>
#include <tchar.h>
#include <string>
#include <sstream>

using namespace std;

class Pong {

private:
	
	bool ballMovingUp;
	bool ballMovingLeft;
	int playerWill;
	int scoreCPU;
	int scorePlayer;
	
public:
	
	static const int playerPaddleSpeed = 5;
	static const int cpuPaddleSpeed = 11;
	static const int xSpeed = 7; //of ball
	static const int ySpeed = 13; //of ball

	public :Pong(void) {
		srand((unsigned int)time_t(0));
		ballMovingUp = false;
		ballMovingLeft = false;
		playerWill = 0;
		scoreCPU = 0;
		scorePlayer = 0;
	}

	void setBallMovingUp(bool newVal) {
		ballMovingUp = newVal;
	}
	void setBallMovingLeft(bool newVal) {
		ballMovingLeft = newVal;
	}
	void changeVerticalDirection() {
		if(ballMovingUp)
			ballMovingUp = false;
		else
			ballMovingUp = true;
	}
	void changeHorizontalDirection() {
		if(ballMovingLeft)
			ballMovingLeft = false;
		else
			ballMovingLeft = true;
	}
	bool isBallMovingUp() {
		return ballMovingUp;
	}
	bool isBallMovingLeft() {
		return ballMovingLeft;
	}

	void incScorePlayer() {
		scorePlayer++;
	}
	void incScoreCPU() {
		scoreCPU++;
	}

	int getPlayerWill() {
		return playerWill;
	}
	void setPlayerWillUp() {
		playerWill = -playerPaddleSpeed;
	}
	void setPlayerWillDown() {
		playerWill = playerPaddleSpeed;
	}
	void setPlayerWillNone() {
		playerWill = 0;
	}

	wstring getScore() {
		std::stringstream ss;
		ss << "Player " << this->scorePlayer << " : " << this->scoreCPU << " CPU";
		std::string str = ss.str();
		std::wstring wstr(str.length(), L' ');
		std::copy(str.begin(), str.end(), wstr.begin());

		return wstr;
	}

} p;
