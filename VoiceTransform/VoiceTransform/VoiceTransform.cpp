// VoiceTransform.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "SkyVoice.h"

extern "C" _declspec(dllexport) bool Initialize(char *fileName, int &speekerNum);
extern "C" _declspec(dllexport) bool SetSpeeker(int speakerId);
extern "C" _declspec(dllexport) void ReadText(char* text);
extern "C"  _declspec(dllexport) void Stop();
extern "C" _declspec(dllexport) void Uninitialize();
extern "C" _declspec(dllexport) void test();


#pragma comment (lib, "SkyVoice.lib") 

static SPEAKERINFO spkInfo;
//��ʼ��
bool Initialize(char *fileName, int &speekerNum)
{
	speekerNum = 0;
	//if (ttsInitial("./SkyVoice.ini"))
	if (ttsInitial(fileName))
		return false;

	//SPEAKERINFO spkInfo;
	ttsGetAudLibInfoList(MANDARIN, &spkInfo);
	int nMandAudLibNum = spkInfo.m_nSpeakerNum;
	if (nMandAudLibNum <= 0)
		return false;

	speekerNum = spkInfo.m_nSpeakerNum;
	return true;
}

bool SetSpeeker(int speakerId)
{
	ttsSetAudLib(MANDARIN, spkInfo.m_szSpeakerName[speakerId]);

	return true;
}

void ReadText(char* text)
{
	ttsPlay(0, text);
}

void Stop()
{
	ttsStop();
}

void Uninitialize()
{
	ttsClose();
}

void test(char* configFile)
{
	int Num = 0;
	//Initialize(configFile, Num);
	
	Initialize("./SkyVoice.ini", Num);
	SetSpeeker(0);
	ReadText("�������ԣ����Գɹ�");

	SetSpeeker(1);
	ReadText("Ů�����ԣ����Գɹ�");

	Uninitialize();
}