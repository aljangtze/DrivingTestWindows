/*=========================================================================*/
/*                                                                         */
/*                              ��������������                             */
/*                         http://www.speechtek.cn/                        */
/*                                                                         */
/*=========================================================================*/
/**
* \file		test.c
* 
* \version	3.0.0
* 
* \brief	����SkyVoice����ļ�����
*/
/*=========================================================================*/
#include <stdio.h>
#include <string.h>
#include <malloc.h>
#include <windows.h>
#include "SkyVoice.h"

#pragma comment (lib, "SkyVoice.lib") 


void play();

void main()
{	
	play();
}



/*-------------------------------------------------------------------------*
*Function:		play
*Description:	�ϳɸ������ı���������
*Parameters:
				none	
*Returns:
				none
*-------------------------------------------------------------------------*/
void play()
{	
	char *szText = "��ӭʹ�����������ϳ�����";
	SPEAKERINFO spkInfo;
	int nMandAudLibNum, i;
	
	
	//����ttsInitial��ʼ��tts��Դ
	//Ĭ�ϵ�����ģʽ�Լ��������Ѿ���SkyVoice.ini�и����������Ҫ�ı���Ե��ýӿ�ttsSetLangMode��ttsSetAudLib������
	if(ttsInitial("./SkyVoice.ini"))	
	{
		printf("ERROR:cannot initialize the system!\n");
		return ;
	}
	printf("\nInitial OK!");

	//�õ���ͨ������������·���б�
	ttsGetAudLibInfoList(MANDARIN, &spkInfo);
	nMandAudLibNum = spkInfo.m_nSpeakerNum;
	if(nMandAudLibNum <= 0)
	{
		printf("ERROR:No Mandarin audio lib!");
		return;
	}		

	//���ε���ÿ�������˽��в���
	for(i = 0; i < nMandAudLibNum; i++)
	{
		ttsSetAudLib(MANDARIN, spkInfo.m_szSpeakerName[i]);

		ttsPlay(0, szText);	

		//���ٷ�������׼���ٵ�0.3��
		ttsSetSpeed(0.3);
		ttsPlay(0, szText);

		//���ټӿ�����׼���ٵ�2��
		ttsSetSpeed(2);
		ttsPlay(0, szText);

		//�ָ�����׼����
		ttsSetSpeed(1.0);

		//��Ƶ��������׼��Ƶ��2��
		ttsSetPitchRatio(2);
		ttsPlay(0, szText);

		//��Ƶ��������׼��Ƶ��0.5��
		ttsSetPitchRatio(0.5);
		ttsPlay(0, szText);

		//�ָ�����׼��Ƶ
		ttsSetPitchRatio(1.0);
		
		//����������׼������1.5��
		ttsSetVolume(1.5);
		ttsPlay(0, szText);

		//������������׼������0.5��
		ttsSetVolume(0.5);
		ttsPlay(0, szText);

		//�ָ�����׼����
		ttsSetVolume(1.0);
	}

	printf("\nSynthesis ok!\n");

	//�ͷ�tts��Դ
	ttsClose();
}
