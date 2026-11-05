"""
Script utilitario de generación de audio placeholder mediante TTS (Microsoft Edge Neural Voices)
100% gratuito y de código abierto (usando edge-tts y ffmpeg).
"""

import asyncio
import os
import subprocess
import edge_tts

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
TAKES_DIR = os.path.join(BASE_DIR, "takes")
os.makedirs(TAKES_DIR, exist_ok=True)

FFMPEG_PATH = r"C:\Users\juanj\AppData\Local\Microsoft\WinGet\Packages\Gyan.FFmpeg_Microsoft.Winget.Source_8wekyb3d8bbwe\ffmpeg-9.0.2-full_build\bin\ffmpeg.exe"

# Voces neuronales en español
VOICE_JUAN = "es-CO-GonzaloNeural"  # Español colombiano masculino (Juan Alvarez)
VOICE_GEFFREY = "es-MX-JorgeNeural"  # Español latino neutro masculino (Geffrey)

BLOQUES = {
    "B0_cold_open_JuanAlvarez": {
        "voice": VOICE_JUAN,
        "rate": "-2%",
        "beats": [
            ("beat_01", "En este preciso segundo, cien mil millones de partículas invisibles nacidas en el corazón del Sol atraviesan la uña de tu pulgar. Y tú no sientes absolutamente nada."),
            ("beat_02", "Al mismo tiempo, en la cima de un cerro en los Andes chilenos, una cámara digital del tamaño de un auto compacto fotografía millones de galaxias buscando una deformación de apenas el uno por ciento."),
            ("beat_03", "Y a cien metros bajo tierra, en la frontera entre Francia y Suiza, un detector de catorce mil toneladas de acero caza los ecos del origen del universo."),
            ("beat_06", "Esta es la historia de cuatro científicos colombianos que decidieron mirar donde nadie más veía. Bienvenidos a la frontera del universo.")
        ]
    },
    "B0_cold_open_Geffrey": {
        "voice": VOICE_GEFFREY,
        "rate": "-2%",
        "beats": [
            ("beat_04", "Parecen postales de otro planeta. Pero detrás de esos tres experimentos, y de las ecuaciones que hoy desafían a Albert Einstein, hay un hilo conductor que casi nadie te cuenta."),
            ("beat_05", "Para entender cómo la física moderna intenta descifrar el noventa y cinco por ciento invisible del cosmos, hay que viajar a Medellín, Chiquinquirá y Bogotá.")
        ]
    }
}

async def generar_bloque(key: str):
    info = BLOQUES[key]
    voice = info["voice"]
    rate = info["rate"]
    beats = info["beats"]
    
    bloque_takes = os.path.join(TAKES_DIR, key)
    os.makedirs(bloque_takes, exist_ok=True)
    
    print(f"\n==========================================")
    print(f"Generando {key} (Voz: {voice})")
    print(f"==========================================")
    
    for beat_id, text in beats:
        mp3_p = os.path.join(bloque_takes, f"{beat_id}.mp3")
        wav_p = os.path.join(bloque_takes, f"{beat_id}.wav")
        print(f"  -> Sintetizando {beat_id}...")
        comm = edge_tts.Communicate(text, voice, rate=rate)
        await comm.save(mp3_p)
        
        # Convertir a WAV 48kHz / 24-bit mono
        cmd = [
            FFMPEG_PATH, "-y",
            "-i", mp3_p,
            "-ar", "48000",
            "-ac", "1",
            "-c:a", "pcm_s24le",
            wav_p
        ]
        subprocess.run(cmd, check=True, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
        
    # Crear silencio de 1.5s
    silence_wav = os.path.join(bloque_takes, "silence_1_5s.wav")
    cmd_silence = [
        FFMPEG_PATH, "-y",
        "-f", "lavfi",
        "-i", "anullsrc=r=48000:cl=mono",
        "-t", "1.5",
        "-c:a", "pcm_s24le",
        silence_wav
    ]
    subprocess.run(cmd_silence, check=True, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
    
    # Lista de concatenación
    concat_list = os.path.join(bloque_takes, "concat_list.txt")
    with open(concat_list, "w", encoding="utf-8") as f:
        for idx, (beat_id, _) in enumerate(beats):
            wav_norm = os.path.join(bloque_takes, f"{beat_id}.wav").replace("\\", "/")
            f.write(f"file '{wav_norm}'\n")
            if idx < len(beats) - 1:
                sil_norm = silence_wav.replace("\\", "/")
                f.write(f"file '{sil_norm}'\n")
                
    master_raw = os.path.join(bloque_takes, "master_raw.wav")
    subprocess.run([
        FFMPEG_PATH, "-y",
        "-f", "concat",
        "-safe", "0",
        "-i", concat_list,
        "-c", "copy",
        master_raw
    ], check=True, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
    
    # Normalizar a -14 LUFS para export final
    final_wav = os.path.join(BASE_DIR, f"{key}.wav")
    subprocess.run([
        FFMPEG_PATH, "-y",
        "-i", master_raw,
        "-af", "loudnorm=I=-14:TP=-1.0:LRA=11",
        "-ar", "48000",
        "-ac", "1",
        "-c:a", "pcm_s24le",
        final_wav
    ], check=True, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
    
    print(f"✅ Exportado correctamente: {final_wav}")

if __name__ == "__main__":
    asyncio.run(generar_bloque("B0_cold_open_JuanAlvarez"))
