"""
Script automatizado de descarga de assets audiovisuales públicos
Usa yt-dlp (open source), curl y endpoints oficiales (NASA / Wikimedia Commons)
"""

import os
import subprocess
import urllib.request
import json
import time

DEST_DIR = r"c:\Proyectos\proyecto-particulas-cosmologia\02_assets\archivo_publico"
os.makedirs(DEST_DIR, exist_ok=True)

USER_AGENT = 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36'
HEADERS = {'User-Agent': 'CosmologyDocumentaryProject/1.0 (educational open science)'}

def download_file_curl(url, out_path):
    print(f"\n[Descargando con curl]: {out_path} ...")
    cmd = [
        "curl.exe", "-s", "-L",
        "-A", USER_AGENT,
        "-o", out_path,
        url
    ]
    res = subprocess.run(cmd)
    if os.path.exists(out_path) and os.path.getsize(out_path) > 0:
        print(f"  -> Guardado exitosamente: {os.path.getsize(out_path):,} bytes")
    else:
        print(f"  -> Error al descargar {url}")

def get_wikimedia_url(filename):
    url = f"https://commons.wikimedia.org/w/api.php?action=query&titles={urllib.parse.quote(filename)}&prop=imageinfo&iiprop=url|size|mime&format=json"
    req = urllib.request.Request(url, headers=HEADERS)
    data = json.loads(urllib.request.urlopen(req, timeout=15).read())
    pages = data.get('query', {}).get('pages', {})
    for pid, pdata in pages.items():
        ii = pdata.get('imageinfo', [{}])[0]
        return ii.get('url')
    return None

def download_youtube_clip(url, section, out_path):
    print(f"\n[Descargando clip de YouTube con yt-dlp]: {out_path}")
    print(f"  URL: {url} (Sección: {section})")
    cmd = [
        "uvx", "yt-dlp",
        "--download-sections", section,
        "-f", "bestvideo[height<=1080][ext=mp4]+bestaudio[ext=m4a]/best[height<=1080][ext=mp4]/best",
        "--force-keyframes-at-cuts",
        "-o", out_path,
        "--no-playlist",
        url
    ]
    res = subprocess.run(cmd, stdout=subprocess.PIPE, stderr=subprocess.STDOUT, text=True)
    if os.path.exists(out_path) and os.path.getsize(out_path) > 0:
        print(f"  -> Clip descargado exitosamente: {os.path.getsize(out_path):,} bytes")
    else:
        # Retry with simpler format if needed
        cmd_fallback = [
            "uvx", "yt-dlp",
            "--download-sections", section,
            "-f", "best[ext=mp4]/best",
            "--force-keyframes-at-cuts",
            "-o", out_path,
            "--no-playlist",
            url
        ]
        res_fb = subprocess.run(cmd_fallback, stdout=subprocess.PIPE, stderr=subprocess.STDOUT, text=True)
        if os.path.exists(out_path) and os.path.getsize(out_path) > 0:
            print(f"  -> Clip descargado con fallback: {os.path.getsize(out_path):,} bytes")
        else:
            print(f"  -> Error en descarga de {url}:\n{res.stdout[-300:]}")

def main():
    print("=== INICIANDO DESCARGA DE ASSETS AUDIOVISUALES PÚBLICOS ===")
    
    # 1. ASSET-01: NASA SDO Solar Flare Video
    out_01 = os.path.join(DEST_DIR, "01_sol_sdo_flares.mp4")
    if not os.path.exists(out_01):
        url_01 = "http://images-assets.nasa.gov/video/GSFC_20160426_SDO_m12224_SolarFlare/GSFC_20160426_SDO_m12224_SolarFlare~large.mp4"
        download_file_curl(url_01, out_01)
    else:
        print(f"ASSET-01 ya existe ({os.path.getsize(out_01):,} bytes)")

    # 2. ASSET-04: JWST SMACS 0723 Gravitational Lensing
    out_04 = os.path.join(DEST_DIR, "04_hubble_jwst_gravitational_lensing.jpg")
    if not os.path.exists(out_04):
        url_04 = "http://images-assets.nasa.gov/image/PIA25327/PIA25327~orig.jpg"
        download_file_curl(url_04, out_04)
    else:
        print(f"ASSET-04 ya existe ({os.path.getsize(out_04):,} bytes)")

    # 3. ASSET-16: Pale Blue Dot (Voyager 1 / NASA JPL)
    out_16 = os.path.join(DEST_DIR, "16_voyager_pale_blue_dot.jpg")
    if not os.path.exists(out_16):
        url_16 = "http://images-assets.nasa.gov/image/PIA23645/PIA23645~orig.jpg"
        download_file_curl(url_16, out_16)
    else:
        print(f"ASSET-16 ya existe ({os.path.getsize(out_16):,} bytes)")

    # 4. ASSET-07: Fermilab Wilson Hall
    out_07 = os.path.join(DEST_DIR, "07_fermilab_wilson_hall.jpg")
    if not os.path.exists(out_07):
        time.sleep(1)
        url_07 = get_wikimedia_url("File:Fermilab Robert Rathbun Wilson Hall 2011.jpg")
        if url_07:
            download_file_curl(url_07, out_07)
    else:
        print(f"ASSET-07 ya existe ({os.path.getsize(out_07):,} bytes)")

    # 5. ASSET-08: DECam Focal Plane 62 CCDs
    out_08 = os.path.join(DEST_DIR, "08_decam_focal_plane.jpg")
    if not os.path.exists(out_08):
        time.sleep(1)
        url_08 = get_wikimedia_url("File:Close-up photo of DECam (noirlab2027e).jpg")
        if url_08:
            download_file_curl(url_08, out_08)
    else:
        print(f"ASSET-08 ya existe ({os.path.getsize(out_08):,} bytes)")

    # 6. ASSET-12: CMS Higgs Event Display 4-muon
    out_12 = os.path.join(DEST_DIR, "12_cms_higgs_event_display.jpg")
    if not os.path.exists(out_12):
        time.sleep(1)
        url_12 = get_wikimedia_url("File:CMS Higgs-event.jpg")
        if url_12:
            download_file_curl(url_12, out_12)
    else:
        print(f"ASSET-12 ya existe ({os.path.getsize(out_12):,} bytes)")

    # 7. ASSET-14: OAN Cúpula histórica Bogotá (1803)
    out_14 = os.path.join(DEST_DIR, "14_oan_cupula_historica_1803.jpg")
    if not os.path.exists(out_14):
        time.sleep(1)
        url_14 = get_wikimedia_url("File:Observatorio Astronómico Nacional Bogotá.jpeg")
        if url_14:
            download_file_curl(url_14, out_14)
    else:
        print(f"ASSET-14 ya existe ({os.path.getsize(out_14):,} bytes)")

    # 8. ASSET-05: Ciudad Universitaria UdeA Medellín
    out_05 = os.path.join(DEST_DIR, "05_udea_campus_facultad.jpg")
    if not os.path.exists(out_05):
        time.sleep(1)
        url_05 = get_wikimedia_url("File:UdeA.CiudadUniversitaria.jpg")
        if url_05:
            download_file_curl(url_05, out_05)
    else:
        print(f"ASSET-05 ya existe ({os.path.getsize(out_05):,} bytes)")

    # 9. ASSET-03 / 11: CERN CMS Detector Cavern & LHC Tunnel
    out_03 = os.path.join(DEST_DIR, "03_cern_cms_cavern_broll.jpg")
    if not os.path.exists(out_03):
        time.sleep(1)
        url_03 = get_wikimedia_url("File:CMS detector (2).jpg")
        if url_03:
            download_file_curl(url_03, out_03)
    else:
        print(f"ASSET-03 ya existe ({os.path.getsize(out_03):,} bytes)")

    out_11 = os.path.join(DEST_DIR, "11_cern_lhc_tunnel.jpg")
    if not os.path.exists(out_11):
        time.sleep(1)
        url_11 = get_wikimedia_url("File:Views of the LHC tunnel sector 3-4, tirage 2.jpg")
        if url_11:
            download_file_curl(url_11, out_11)
    else:
        print(f"ASSET-11 ya existe ({os.path.getsize(out_11):,} bytes)")

    # 10. CLIPS DE VIDEO YOUTUBE (CITA EDUCATIVA / CC BY):
    # ASSET-06: Diego Restrepo / Partículas en el Valle (UdeA)
    out_06 = os.path.join(DEST_DIR, "06_particulas_valle_restrepo.mp4")
    if not os.path.exists(out_06):
        download_youtube_clip("https://www.youtube.com/watch?v=Brfj8ziHxV8", "*01:30-02:00", out_06)
    else:
        print(f"ASSET-06 ya existe ({os.path.getsize(out_06):,} bytes)")

    # ASSET-10: Andrés Plazas / Big Astronomy
    out_10 = os.path.join(DEST_DIR, "10_big_astronomy_andres_plazas.mp4")
    if not os.path.exists(out_10):
        download_youtube_clip("https://www.youtube.com/watch?v=-U34UhMZBuI", "*03:15-03:45", out_10)
    else:
        print(f"ASSET-10 ya existe ({os.path.getsize(out_10):,} bytes)")

    # ASSET-13: Juan Carlos Sanabria / Espías Nucleares (Uniandes)
    out_13 = os.path.join(DEST_DIR, "13_uniandes_presentacion_sanabria.mp4")
    if not os.path.exists(out_13):
        download_youtube_clip("https://www.youtube.com/watch?v=CPLiI4GPgRg", "*02:00-02:30", out_13)
    else:
        print(f"ASSET-13 ya existe ({os.path.getsize(out_13):,} bytes)")

    # ASSET-15: Leonardo Castañeda / OAN Colombia
    out_15 = os.path.join(DEST_DIR, "15_oan_jueves_estrellas_castaneda.mp4")
    if not os.path.exists(out_15):
        download_youtube_clip("https://www.youtube.com/watch?v=dzJ-RQFijrk", "*01:30-02:00", out_15)
    else:
        print(f"ASSET-15 ya existe ({os.path.getsize(out_15):,} bytes)")

    print("\n=== RESUMEN FINAL DE ASSETS DESCARGADOS ===")
    for item in sorted(os.listdir(DEST_DIR)):
        p = os.path.join(DEST_DIR, item)
        if os.path.isfile(p) and not item.startswith("."):
            print(f"  - {item:42} : {os.path.getsize(p):,} bytes")

if __name__ == "__main__":
    main()
