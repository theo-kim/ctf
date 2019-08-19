.class final Lcom/fireeye/flarebear/FlareBearActivity$activityUi$3;
.super Ljava/lang/Object;
.source "FlareBearActivity.kt"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/fireeye/flarebear/FlareBearActivity;->activityUi(Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = null
.end annotation

.annotation runtime Lkotlin/Metadata;
    bv = {
        0x1,
        0x0,
        0x3
    }
    d1 = {
        "\u0000\u0008\n\u0000\n\u0002\u0010\u0002\n\u0000\u0010\u0000\u001a\u00020\u0001H\n\u00a2\u0006\u0002\u0008\u0002"
    }
    d2 = {
        "<anonymous>",
        "",
        "run"
    }
    k = 0x3
    mv = {
        0x1,
        0x1,
        0xf
    }
.end annotation


# instance fields
.field final synthetic this$0:Lcom/fireeye/flarebear/FlareBearActivity;


# direct methods
.method constructor <init>(Lcom/fireeye/flarebear/FlareBearActivity;)V
    .locals 0

    iput-object p1, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$3;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 1

    .line 217
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$3;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    invoke-virtual {v0}, Lcom/fireeye/flarebear/FlareBearActivity;->setMood()V

    .line 218
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$3;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    invoke-static {v0}, Lcom/fireeye/flarebear/FlareBearActivity;->access$addPoos(Lcom/fireeye/flarebear/FlareBearActivity;)V

    .line 220
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$3;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    invoke-static {v0}, Lcom/fireeye/flarebear/FlareBearActivity;->access$changeFlareBearImage(Lcom/fireeye/flarebear/FlareBearActivity;)V

    return-void
.end method
