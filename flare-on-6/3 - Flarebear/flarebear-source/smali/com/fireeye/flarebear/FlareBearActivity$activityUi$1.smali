.class final Lcom/fireeye/flarebear/FlareBearActivity$activityUi$1;
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
.field final synthetic $drawable2:Landroid/graphics/drawable/Drawable;

.field final synthetic this$0:Lcom/fireeye/flarebear/FlareBearActivity;


# direct methods
.method constructor <init>(Lcom/fireeye/flarebear/FlareBearActivity;Landroid/graphics/drawable/Drawable;)V
    .locals 0

    iput-object p1, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    iput-object p2, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$1;->$drawable2:Landroid/graphics/drawable/Drawable;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 200
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    sget v1, Lcom/fireeye/flarebear/R$id;->flareBearImageView:I

    invoke-virtual {v0, v1}, Lcom/fireeye/flarebear/FlareBearActivity;->_$_findCachedViewById(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/widget/ImageView;

    iget-object v1, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$1;->$drawable2:Landroid/graphics/drawable/Drawable;

    invoke-virtual {v0, v1}, Landroid/widget/ImageView;->setImageDrawable(Landroid/graphics/drawable/Drawable;)V

    .line 201
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$activityUi$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    sget v1, Lcom/fireeye/flarebear/R$id;->flareBearImageView:I

    invoke-virtual {v0, v1}, Lcom/fireeye/flarebear/FlareBearActivity;->_$_findCachedViewById(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/widget/ImageView;

    const-string v1, "activity2"

    invoke-virtual {v0, v1}, Landroid/widget/ImageView;->setTag(Ljava/lang/Object;)V

    return-void
.end method
