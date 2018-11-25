export interface OrderDetailsModel {
    CycleQuantity: number;
    ModelType: string;
    HandlebarTypeId: number;
    PlasticsColorTypeId: number;
    SprintShiftTypeId: number;
    PowerMeterTypeId: number;
    PedalTypeId?: number;
    ConsoleTypeId?: number;
    SeatTypeId?: number;
    ArtworkBeltGuardId?: number;
    ArtworkBeltGuardColor: string;
    ArtworkBeltGuardImageUrl: FormData;
    ArtworkFlywheelId?: number;
    ArtworkFlywheelColor: string;
    ArtworkFlywheelImageUrl: FormData;
    ArtworkFrameForkId?: number;
    ArtworkFrameForkColor: string;
    ArtworkFrameForkImageUrl: FormData;
    PaintColorId: number;
    CustomColor: string;
}
