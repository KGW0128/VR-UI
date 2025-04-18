# 🧠 VR 인벤토리 & 칠판 드로잉 시스템 (Unity + SteamVR 프로젝트)

> 본 프로젝트는 **Unity**와 **SteamVR**을 활용하여, 공간 기반 UI와 인터랙션을 구현한 VR 응용 프로젝트입니다.  
> 마우스 입력도 지원하여 비 VR 환경에서도 테스트 및 사용이 가능합니다.  
> 👉 개발 관련 더 많은 정보는 [GPT온라인](https://gptonline.ai/ko/)에서 확인하세요.

---

## 🔧 프로젝트 개요

- 공간상의 **인벤토리 UI**와 **장비 시스템** 구현  
- **필드 아이템** 상호작용 및 드래그 앤 드롭 기반 정렬, 장착 기능  
- **공간 또는 벽(칠판)**에 라인 드로잉 기능 제공 (Tilt Brush 스타일)  
- VR 컨트롤러 또는 **마우스 클릭 기반 입력** 지원  
- 라인 색상/두께 변경 및 **저장/로드** 기능 포함

---

## 📌 핵심 기능 요약

### 🎒 인벤토리 시스템
- **공간 UI** 기반 인벤토리 및 장비창 구현
- 필드 상의 아이템을 클릭 시, 해당 아이템을 공간 UI에 표시하고 인벤토리에 등록
- 인벤토리 내 아이템을 **드래그하여 장착/해제**
- 아이템 드롭 시, 특정 UI에 드롭하여 필드에 버리는 기능

### 🖍 칠판 드로잉 시스템 (Tilt Brush 스타일)
- 플레이어가 **공간 혹은 벽면에 직접 라인을 그릴 수 있음**
- SteamVR 컨트롤러 또는 마우스 입력 지원
- 라인 **두께/색상 조절 기능**
- 그린 라인 데이터 **저장 및 불러오기 기능**

---

## 🧪 사용 기술 (Tech Stack)

- Unity 2021+
- SteamVR Plugin
- C# (MonoBehaviour 기반 시스템 설계)
- VR/PC 하이브리드 입력 처리
- Player Prefab 구조 기반 상호작용 시스템
- ScriptableObject (데이터 저장/로드 구조 설계 시 사용 가능)
- Layer/Tag 시스템을 활용한 UI/오브젝트 구분 처리

---

## ▶️ 실행 방법
-파일 안 boc 확인

---
