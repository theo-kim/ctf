.class public final Lcom/fireeye/flarebear/FlareBearActivity$changeFlareBearImage$r$1;
.super Ljava/lang/Object;
.source "FlareBearActivity.kt"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/fireeye/flarebear/FlareBearActivity;->changeFlareBearImage()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation

.annotation runtime Lkotlin/Metadata;
    bv = {
        0x1,
        0x0,
        0x3
    }
    d1 = {
        "\u0000\u0011\n\u0000\n\u0002\u0018\u0002\n\u0000\n\u0002\u0010\u0002\n\u0000*\u0001\u0000\u0008\n\u0018\u00002\u00020\u0001J\u0008\u0010\u0002\u001a\u00020\u0003H\u0016\u00a8\u0006\u0004"
    }
    d2 = {
        "com/fireeye/flarebear/FlareBearActivity$changeFlareBearImage$r$1",
        "Ljava/lang/Runnable;",
        "run",
        "",
        "app_release"
    }
    k = 0x1
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
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 76
    iput-object p1, p0, Lcom/fireeye/flarebear/FlareBearActivity$changeFlareBearImage$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    .line 78
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$changeFlareBearImage$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    invoke-virtual {v0}, Lcom/fireeye/flarebear/FlareBearActivity;->getHandler()Landroid/os/Handler;

    move-result-object v0

    move-object v1, p0

    check-cast v1, Ljava/lang/Runnable;

    const-wide/16 v2, 0x5dc

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 79
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$changeFlareBearImage$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    invoke-virtual {v0}, Lcom/fireeye/flarebear/FlareBearActivity;->changeImageAndTag()V

    return-void
.end method
