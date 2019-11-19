/*=========================================================================*/
/*                                                                         */
/*                              慧声语音工作室                             */
/*                         http://www.speechtek.cn/                        */
/*                                                                         */
/*=========================================================================*/
/**
* \file		test.c
* 
* \version	3.0.0
* 
* \brief	调用SkyVoice引擎的简单例子
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
*Description:	合成给定的文本，并播放
*Parameters:
				none	
*Returns:
				none
*-------------------------------------------------------------------------*/
void play()
{	
	char *szText = "欢迎使用朗声语音合成引擎";
	SPEAKERINFO spkInfo;
	int nMandAudLibNum, i;
	
	
	//调用ttsInitial初始化tts资源
	//默认的语言模式以及发音人已经在SkyVoice.ini中给定，如果需要改变可以调用接口ttsSetLangMode和ttsSetAudLib来更改
	if(ttsInitial("./SkyVoice.ini"))	
	{
		printf("ERROR:cannot initialize the system!\n");
		return ;
	}
	printf("\nInitial OK!");

	//得到普通话发音人音库路径列表
	ttsGetAudLibInfoList(MANDARIN, &spkInfo);
	nMandAudLibNum = spkInfo.m_nSpeakerNum;
	if(nMandAudLibNum <= 0)
	{
		printf("ERROR:No Mandarin audio lib!");
		return;
	}		

	//依次调用每个发音人进行播放
	for(i = 0; i < nMandAudLibNum; i++)
	{
		ttsSetAudLib(MANDARIN, spkInfo.m_szSpeakerName[i]);

		ttsPlay(0, szText);	

		//语速放慢至标准语速的0.3倍
		ttsSetSpeed(0.3);
		ttsPlay(0, szText);

		//语速加快至标准语速的2倍
		ttsSetSpeed(2);
		ttsPlay(0, szText);

		//恢复至标准语速
		ttsSetSpeed(1.0);

		//基频提升至标准基频的2倍
		ttsSetPitchRatio(2);
		ttsPlay(0, szText);

		//基频降低至标准基频的0.5倍
		ttsSetPitchRatio(0.5);
		ttsPlay(0, szText);

		//恢复至标准基频
		ttsSetPitchRatio(1.0);
		
		//音量升至标准音量的1.5倍
		ttsSetVolume(1.5);
		ttsPlay(0, szText);

		//音量降至至标准音量的0.5倍
		ttsSetVolume(0.5);
		ttsPlay(0, szText);

		//恢复至标准音量
		ttsSetVolume(1.0);
	}

	printf("\nSynthesis ok!\n");

	//释放tts资源
	ttsClose();
}
