.class public final Lcom/fireeye/flarebear/FlareBearActivityKt;
.super Ljava/lang/Object;
.source "FlareBearActivity.kt"


# annotations
.annotation system Ldalvik/annotation/SourceDebugExtension;
    value = "SMAP\nFlareBearActivity.kt\nKotlin\n*S Kotlin\n*F\n+ 1 FlareBearActivity.kt\ncom/fireeye/flarebear/FlareBearActivityKt\n*L\n1#1,525:1\n*E\n"
.end annotation

.annotation runtime Lkotlin/Metadata;
    bv = {
        0x1,
        0x0,
        0x3
    }
    d1 = {
        "\u0000$\n\u0000\n\u0002\u0010\u0008\n\u0002\u0008\u0006\n\u0002\u0010\u000e\n\u0002\u0008\u0004\n\u0002\u0010\u0007\n\u0002\u0008\u0003\n\u0002\u0010!\n\u0002\u0018\u0002\n\u0000\"\u000e\u0010\u0000\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u0002\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u0003\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u0004\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u0005\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u0006\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u0007\u001a\u00020\u0008X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\t\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\n\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u000b\u001a\u00020\u0001X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u000c\u001a\u00020\rX\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u000e\u001a\u00020\u0008X\u0082T\u00a2\u0006\u0002\n\u0000\"\u000e\u0010\u000f\u001a\u00020\u0008X\u0082T\u00a2\u0006\u0002\n\u0000\"\u0014\u0010\u0010\u001a\u0008\u0012\u0004\u0012\u00020\u00120\u0011X\u0082\u000e\u00a2\u0006\u0002\n\u0000\u00a8\u0006\u0013"
    }
    d2 = {
        "CLEAN_PER_CLEAN",
        "",
        "CLEAN_PER_FEED",
        "CLEAN_PER_PLAY",
        "HAPPY_PER_CLEAN",
        "HAPPY_PER_FEED",
        "HAPPY_PER_PLAY",
        "IV",
        "",
        "MASS_PER_CLEAN",
        "MASS_PER_FEED",
        "MASS_PER_PLAY",
        "POOS_PER_FEED",
        "",
        "SALT",
        "TAG",
        "poosList",
        "",
        "Landroid/widget/ImageView;",
        "app_release"
    }
    k = 0x2
    mv = {
        0x1,
        0x1,
        0xf
    }
.end annotation


# static fields
.field private static final CLEAN_PER_CLEAN:I = 0x6

.field private static final CLEAN_PER_FEED:I = -0x1

.field private static final CLEAN_PER_PLAY:I = -0x1

.field private static final HAPPY_PER_CLEAN:I = -0x1

.field private static final HAPPY_PER_FEED:I = 0x2

.field private static final HAPPY_PER_PLAY:I = 0x4

.field private static final IV:Ljava/lang/String; = "pawsitive_vibes!"

.field private static final MASS_PER_CLEAN:I = 0x0

.field private static final MASS_PER_FEED:I = 0xa

.field private static final MASS_PER_PLAY:I = -0x2

.field private static final POOS_PER_FEED:F = 0.34f

.field private static final SALT:Ljava/lang/String; = "NaClNaClNaCl"

.field private static final TAG:Ljava/lang/String; = "FLARE Bear"

.field private static poosList:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Landroid/widget/ImageView;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 53
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    check-cast v0, Ljava/util/List;

    sput-object v0, Lcom/fireeye/flarebear/FlareBearActivityKt;->poosList:Ljava/util/List;

    return-void
.end method

.method public static final synthetic access$getPoosList$p()Ljava/util/List;
    .locals 1

    .line 1
    sget-object v0, Lcom/fireeye/flarebear/FlareBearActivityKt;->poosList:Ljava/util/List;

    return-object v0
.end method

.method public static final synthetic access$setPoosList$p(Ljava/util/List;)V
    .locals 0

    .line 1
    sput-object p0, Lcom/fireeye/flarebear/FlareBearActivityKt;->poosList:Ljava/util/List;

    return-void
.end method
