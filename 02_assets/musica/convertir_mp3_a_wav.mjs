import { execSync } from 'child_process';
import fs from 'fs';
import path from 'path';

const dir = path.resolve('02_assets/musica');
const mp3Files = fs.readdirSync(dir).filter(f => f.endsWith('.mp3'));

console.log(`Convirtiendo ${mp3Files.length} archivos MP3 a WAV (48 kHz / 24-bit PCM)...`);

for (const mp3 of mp3Files) {
  const wav = mp3.replace(/\.mp3$/, '.wav');
  const mp3Path = path.join(dir, mp3);
  const wavPath = path.join(dir, wav);

  if (!fs.existsSync(wavPath)) {
    console.log(`Generando: ${wav}`);
    execSync(`ffmpeg -y -i "${mp3Path}" -ar 48000 -acodec pcm_s24le "${wavPath}"`, { stdio: 'inherit' });
  } else {
    console.log(`Ya existe: ${wav}`);
  }
}

console.log('Proceso completado con éxito.');
