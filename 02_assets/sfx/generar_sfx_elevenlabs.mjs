import fs from 'fs';
import path from 'path';
import { execSync } from 'child_process';

const envContent = fs.readFileSync('.env', 'utf8');
const match = envContent.match(/ELEVENLABS_API_KEY=([^\r\n]+)/);
const apiKey = match ? match[1].trim() : process.env.ELEVENLABS_API_KEY;

if (!apiKey) {
  console.error('Error: ELEVENLABS_API_KEY not found in .env or environment');
  process.exit(1);
}

const sfxList = [
  {
    id: 'SFX-01',
    beat: 'Beat 01',
    filename: 'hum_subatomico.wav',
    duration: 4.0,
    influence: 0.45,
    prompt: 'Deep subatomic hum drone, low-frequency ambient rumble, cosmic dark matter vibration, clean sci-fi sub bass tone'
  },
  {
    id: 'SFX-02',
    beat: 'Beat 03',
    filename: 'pulso_cern.wav',
    duration: 3.5,
    influence: 0.45,
    prompt: 'Heavy electromagnetic pulse, particle accelerator magnetic charge buildup and release with underground cavern metallic reverb'
  },
  {
    id: 'SFX-03',
    beat: 'Beat 05',
    filename: 'sello_golpe.wav',
    duration: 3.0,
    influence: 0.5,
    prompt: 'Four rhythmic heavy mechanical ink rubber stamp thuds on thick textured paper, printing press thumps'
  },
  {
    id: 'SFX-04',
    beat: 'Beat 07',
    filename: 'fosforo_strike.wav',
    duration: 2.0,
    influence: 0.5,
    prompt: 'Crisp wooden match strike on matchbox sandpaper friction and instant burst of fire flame ignition'
  },
  {
    id: 'SFX-05',
    beat: 'Beat 08',
    filename: 'papel_rasgado.wav',
    duration: 2.5,
    influence: 0.5,
    prompt: 'Slow textured tearing sound of thick heavy cardboard paper, clean foley rip'
  },
  {
    id: 'SFX-06',
    beat: 'Beat 10',
    filename: 'pop_acordeon.wav',
    duration: 1.5,
    influence: 0.4,
    prompt: 'Clean smooth card pop sound, swift paper accordion unfolding snap, modern UI interface pop'
  },
  {
    id: 'SFX-07',
    beat: 'Beat 21',
    filename: 'grieta_monolito.wav',
    duration: 3.0,
    influence: 0.45,
    prompt: 'Heavy stone monolith cracking, deep resonant rock fissure fracture, crystalline tension snap'
  },
  {
    id: 'SFX-08',
    beat: 'Beat 28',
    filename: 'clics_cascada.wav',
    duration: 2.0,
    influence: 0.4,
    prompt: 'Rapid burst of crisp digital clicks, high-speed computer data stream readout, mechanical switches'
  },
  {
    id: 'SFX-09',
    beat: 'Beat 31',
    filename: 'pluma_tinta.wav',
    duration: 1.5,
    influence: 0.5,
    prompt: 'Fast sharp fountain pen scratching vigorously crossing out words on paper, realistic writing foley'
  },
  {
    id: 'SFX-10',
    beat: 'Beat 34',
    filename: 'refraccion_lente.wav',
    duration: 3.0,
    influence: 0.45,
    prompt: 'Pristine crystalline glass chime, optical lens light refraction shimmer, ethereal delicate resonant glass tone'
  },
  {
    id: 'SFX-11',
    beat: 'Beat 37',
    filename: 'sonar_alerta.wav',
    duration: 2.0,
    influence: 0.45,
    prompt: 'Subtle high-tech astronomical observatory sonar ping, quiet alert chime, clean electronic acoustic echo'
  }
];

const outDir = path.resolve('02_assets/sfx');
if (!fs.existsSync(outDir)) {
  fs.mkdirSync(outDir, { recursive: true });
}

async function generateAll() {
  console.log(`Starting generation of ${sfxList.length} sound effects using ElevenLabs SFX v3...`);
  
  for (let i = 0; i < sfxList.length; i++) {
    const item = sfxList[i];
    const targetWav = path.join(outDir, item.filename);
    const tempMp3 = path.join(outDir, `temp_${item.filename.replace('.wav', '.mp3')}`);

    console.log(`\n[${i + 1}/${sfxList.length}] Generating ${item.filename} (${item.beat})...`);
    console.log(`  Prompt: "${item.prompt}"`);

    const payload = {
      text: item.prompt,
      duration_seconds: item.duration,
      prompt_influence: item.influence,
      model_id: 'eleven_text_to_sound_v3'
    };

    try {
      const res = await fetch('https://api.elevenlabs.io/v1/sound-generation', {
        method: 'POST',
        headers: {
          'xi-api-key': apiKey,
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
      });

      if (!res.ok) {
        const errText = await res.text();
        throw new Error(`HTTP ${res.status} ${res.statusText}: ${errText}`);
      }

      const buffer = Buffer.from(await res.arrayBuffer());
      fs.writeFileSync(tempMp3, buffer);

      // Convert MP3 to 48kHz stereo WAV using ffmpeg
      execSync(`ffmpeg -y -v quiet -i "${tempMp3}" -ar 48000 "${targetWav}"`);
      if (fs.existsSync(tempMp3)) {
        fs.unlinkSync(tempMp3);
      }

      const stats = fs.statSync(targetWav);
      console.log(`  ✓ Successfully generated ${item.filename} (${(stats.size / 1024).toFixed(1)} KB, 48kHz WAV)`);
    } catch (err) {
      console.error(`  ✗ Failed to generate ${item.filename}:`, err.message);
      if (fs.existsSync(tempMp3)) {
        fs.unlinkSync(tempMp3);
      }
    }
  }

  console.log('\n=== Generation Complete ===');
}

generateAll();
