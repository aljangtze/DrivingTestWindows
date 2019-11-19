/*=========================================================================*/
/*                                                                         */
/*                              慧声语音工作室                             */
/*                         http://www.speechtek.cn/                        */
/*                                                                         */
/*=========================================================================*/
/**
 * \file	SkyVoice.h
 * 
 * \version	3.0.0
 * 
 * \brief	Declaration of SkyVoice APIs
 */
/*=========================================================================*/
#ifndef SKYVOICE_H
#define SKYVOICE_H


/** \brief	definition of encoding type*/
#define ENCODING_GB 		1
#define ENCODING_GBK 		2
#define ENCODING_BIG5		3

/** \brief	definition of language mode*/
#define MANDARIN			0

/** \brief	definition of TTS engine status*/
#define TTS_STATUS_UNINITIAL			0    	///<  TTS status is unintialed
#define TTS_STATUS_INVALIDATEHANDLE		1		///<  TTS status is that handle is invalidated
#define TTS_STATUS_IDLE					2		///<  TTS status is idle
#define TTS_STATUS_SYNTHESIS			3		///<  TTS status is synthesising

/** \brief	definition of speaker information*/
#define MAX_SPEAKER_NUM		10
#define MAX_SPEAKER_DESC	256
#define MAX_SPEAKER_PATH	256

/** \brief	Speaker information structure 	*/
typedef struct
{
	int	 m_nSpeakerNum;											///<  number of speakers
	char m_szSpeakerDesc[MAX_SPEAKER_NUM][MAX_SPEAKER_DESC];	///<  description of speakers, e.g., 小严(普通话男声)
	char m_szSpeakerName[MAX_SPEAKER_NUM][MAX_SPEAKER_PATH];	///<  name of speaker audio file, e.g., mandarin/xiaoyan.dat, the name can be used directly as the input parameter of interface ttsSetAudLib
}SPEAKERINFO;


#ifdef __cplusplus
extern "C" {
#endif


/*-------------------------------------------------------------------------*/
/**
 * \brief		Initialize tts with audio function
 * \param	szIniFileName	[in]	full file name of SkyVoice.ini
 * \return	0: success; others: error code
 */
/*-------------------------------------------------------------------------*/
int ttsInitial(char *szIniFileName);



/*-------------------------------------------------------------------------*/
/**
 * \brief		Close tts with audio function
 * \param	none
* \return	0: success; others: error code
 */
/*-------------------------------------------------------------------------*/
int ttsClose();



/*-------------------------------------------------------------------------*/
/**
 * \brief		Query status of TTS engine
 * \param	none
 * \return	status of TTS
 */
/*-------------------------------------------------------------------------*/
int ttsGetStatus();



/*-------------------------------------------------------------------------*/
/**
* \brief	Convert the code of input text to GB encoding type
* \param	szsrcText		[in]	the source text to be converted
* \param	nCodeType		[in]	encoding type of input text, AUTO, GB, GBK, BIG5 are supported
* \param	szConvedText	[out]	the converted text
* \return	0: success;		others: error code
*/
/*-------------------------------------------------------------------------*/
int ttsCodeConvert(char *szSrcText,int nCodeType, char *szConvedText);



/*-------------------------------------------------------------------------*/
/**
* \brief	Run TTS play engine to synthesis text to audio
* \param	hWnd		[in]	handle of current window 
* \param	szText		[in]	input text, the encodeing type must be GB
* \return	0: success, others: error code
*/
/*-------------------------------------------------------------------------*/
int ttsPlay(int hWnd, char *szText);



/*-------------------------------------------------------------------------*/
/**
* \brief		Stop the synthesizing
* \param	none
* \return	0: tts handle is invalid	 	0:success
*/
/*-------------------------------------------------------------------------*/
int ttsStop();



/*-------------------------------------------------------------------------*/
/**
* \brief	Set language mode.
* \param	fSpeed		[in]	the rate of playing speed, 1.0 is the default speed
* \return	0: success,others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsSetLangMode(int nLangMode);



/*-------------------------------------------------------------------------*/
/**
* \brief	Get language mode..
* \param	pnLangMode	[in]	pointer of language mode 
* \return	0: success,others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsGetLangMode(int *pnLangMode);



/*-------------------------------------------------------------------------*/
/**
* \brief	Get the speaker information of specified language.
* \param	nLanguage		[in]	language specified
* \param	pSpeakerInfo	[out]	speaker infomation
* \return	0: others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsGetAudLibInfoList(int nLanguage,SPEAKERINFO* pSpeakerInfo);



/*-------------------------------------------------------------------------*/
/**
* \brief	Set active audio library of specified language, 
* \param	nLanguage		[in]	specified language
* \param	szAudLibName	[in]	name of audio lib to be loaded
* \return	0: success, others: error code
*/
/*-------------------------------------------------------------------------*/
int ttsSetAudLib(int nLanguage, char *szAudLibName);



/*-------------------------------------------------------------------------*/
/**
* \brief	Get the name of active audio library of specified language
* \param	nLanguage		[in]	specified language
* \param	szAudLibName	[in]	name of audio lib to be loaded
* \return	0:success, 	others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsGetAudLib(int nLanguage, char *szAudLibName);



/*-------------------------------------------------------------------------*/
/**
* \brief		Set the playing speed of the specified TTS engine. It's a relative value, 1 is default speed.
* \param	fSpeed		[in]	the rate of playing speed, range from 0.2 to 5.0, 1.0 is the default speed
* \return	0: success, others: error code
*/
/*-------------------------------------------------------------------------*/
int ttsSetSpeed(float fSpeed);



/*-------------------------------------------------------------------------*/
/**
* \brief		Get the playing speed of the specified TTS engine. It's a relative value, 1 is default speed.
* \param	pfSpeed		[out]	pointer of speed 
* \return	0:success, others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsGetSpeed(float *pfSpeed);



/*-------------------------------------------------------------------------*/
/**
* \brief	Set the adjusting ratio of pitch. It's a relative value, 1 is default speed.
* \param	fPitchRatio	[in]	the adjusting ratio of pitch,range from 0.2 to 5.0, 1.0 is the default value
* \return	0:success, others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsSetPitchRatio(float fPitchRatio);



/*-------------------------------------------------------------------------*/
/**
* \brief	Get the adjusting ratio of pitch.. It's a relative value, 1 is default speed.
* \param	pfPitchRatio[in]	pointer of the adjusting ratio of pitch
* \return	0:success, others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsGetPitchRatio(float* pfPitchRatio);



/*-------------------------------------------------------------------------*/
/**
* \brief	Set adjusting ratio of volume.
* \param	fVolume		[in]	volume, range from 0.1 to 2.0, 1.0 is the default volume
* \return	0:success, others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsSetVolume(float fVolume);



/*-------------------------------------------------------------------------*/
/**
* \brief	Get the volume.
* \param	pfVolume	[out]	pointer of volume 
* \return	0:success, others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsGetVolume(float *pfVolume);



/*-------------------------------------------------------------------------*/
/**
* \brief	set whether to set 'return' as end symbol of sentences
* \param	cSet			[in]	 
* \return	0:success, others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsSetRdReturn(char cSet);



/*-------------------------------------------------------------------------*/
/**
* \brief	check whether setting 'return' as end symbol of sentences
* \param	pcSet		[out]	
* \return	0:success, others:error code
*/
/*-------------------------------------------------------------------------*/
int ttsGetRdReturn(char *pcSet);



/*-------------------------------------------------------------------------*/
/**
* \brief	Set the TTS engine to read out symbol,which is ignored in default
* \param	cRdSymbol	[in]	the flag whether read out symbols
* \return	0:success, others:error code	
*/
/*-------------------------------------------------------------------------*/
int ttsSetReadPunc(char cRdSymbol);



/*-------------------------------------------------------------------------*/
/**
* \brief	check whether TTS engin is to read out symbol
* \param	pcRdSymbol	[out]	the flag whether read out symbols
* \return	0:success, others:error code	
*/
/*-------------------------------------------------------------------------*/
int ttsGetReadPunc(char *pcRdSymbol);



#ifdef __cplusplus
}
#endif


#endif
