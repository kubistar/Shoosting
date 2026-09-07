# Shoosting

Unity 2D 종스크롤 슈팅 게임. 바다를 배경으로 스테이지별 보스를 격파하며 진행하고, 보스 처치 보상으로 스도쿠(패널 매칭) 미니게임 조각을 모아 최종 스테이지를 해금하는 구조.

## 데모 영상
[![Demo](https://img.youtube.com/vi/-4l0QEA118g/0.jpg)](https://www.youtube.com/watch?v=-4l0QEA118g)

▶ https://www.youtube.com/watch?v=-4l0QEA118g

## 개발 환경
- Unity 2019.3.15f1
- Target: Standalone Windows
- Language: C# (.NET Standard 2.0)

## 주요 기능
- 8개 스테이지, 스테이지별 고유 패턴을 가진 보스
- 총알 패턴 시스템(`BulletPattern`) — 플레이어 추적, 부채꼴, 시간차 연사 등 다양한 발사 패턴
- 체력/하트 UI, 사망·클리어 연출
- 보스 클리어 시 랜덤 보상(스도쿠 조각) 지급
- 스도쿠 미니게임(패널 드래그 매칭)으로 8스테이지 해금
- BGM/효과음 On/Off 설정, 스테이지 클리어 여부 저장

## 프로젝트 구조
```
Assets/
├── Map/
│   └── BGScrolling.cs          # 배경 스크롤
├── Scripts/
│   ├── InGame/
│   │   ├── Player/
│   │   │   ├── PlayerController.cs   # 이동, 발사 입력
│   │   │   └── PlayerState.cs        # 체력, 사망 처리
│   │   ├── EnemyAI/
│   │   │   ├── EnemyController.cs    # 적 발사 로직
│   │   │   └── EnemyState.cs         # 적 체력, 보상, 클리어 처리
│   │   ├── BulletPattern/
│   │   │   └── BulletPattern.cs      # 총알 발사 패턴 모음
│   │   ├── BulletController.cs       # 총알 이동/소멸
│   │   ├── StageManager.cs           # 적 스폰, 보스 활성화
│   │   ├── GameButtonManager.cs      # 일시정지/재시작/다음 스테이지
│   │   └── InputManager.cs
│   ├── InMain/
│   │   └── MainBTManager.cs          # 메인 화면 UI 전환
│   ├── Manager.cs                    # 전역 상태(싱글톤)
│   ├── SudokuManager.cs              # 스도쿠 미니게임
│   └── panelcheck.cs                 # 패널 드래그 매칭 로직
└── openstage.cs                      # 스테이지 선택 화면 진입 처리
```

## 핵심 구조 설명
- **Manager**: `DontDestroyOnLoad` 싱글톤. 현재 스테이지, 클리어 여부, 사운드 설정 등 씬 전환 간 유지되는 전역 상태를 관리.
- **PlayerState.isEnd**: 플레이어 사망 여부를 나타내는 정적 플래그. 발사·충돌 판정 등 여러 스크립트에서 참조.
- **BulletPattern**: 보스 전용 발사 패턴(`Pattern_1` ~ `Pattern_8`) 모음. `EnemyController`가 `Manager.instance.stageCount` 값으로 어떤 패턴을 쓸지 분기.


## 실행 방법
1. Unity Hub에서 `2019.3.15f1` 버전으로 프로젝트 열기
2. `Assets/Scenes` 하위 `MainScene`을 시작 씬으로 실행
